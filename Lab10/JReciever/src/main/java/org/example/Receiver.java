package org.example;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.rabbitmq.client.Channel;
import com.rabbitmq.client.Connection;
import com.rabbitmq.client.ConnectionFactory;
import com.rabbitmq.client.DeliverCallback;

import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.util.HashMap;
import java.util.Scanner;
import java.util.concurrent.TimeoutException;

public class Receiver {

    private final static String QUEUE_NAME = "hello-world";
    private static final String MESSAGE_END = "KONIEC";
    private static final String SENDER_ID = "SenderId";

    public static void rabbit(ConnectionFactory factory) throws IOException, TimeoutException {

        Connection connection = factory.newConnection();
        Channel channel = connection.createChannel();
        HashMap<Object, Boolean> senders = new HashMap<Object, Boolean>();

        channel.queueDeclare(QUEUE_NAME, false, false, false, null);
        System.out.println("- Oczekuje na wiadomości");

        DeliverCallback deliverCallback = (consumerTag, delivery) -> {
            String messageJson = new String(delivery.getBody(), StandardCharsets.UTF_8);
            var headers = delivery.getProperties().getHeaders();

            System.out.println("- Wiadomość:\n '" + messageJson + "'");

            if(headers != null && headers.containsKey(SENDER_ID)){
                if (messageJson.equals(MESSAGE_END)) {
                    senders.put(headers.get(SENDER_ID), false);
                    boolean ended = senders.values().stream().noneMatch(value -> value);
                    if(ended){
                        try {
                            Scanner scn = new Scanner(System.in);
                            System.out.println("Wpisz \"again\" aby ponowić, cokolwiek aby zakończyć");

                            if(!scn.nextLine().equals("again")){
                                System.out.println("end");
                                channel.close();
                                connection.close();
                                System.exit(0);
                            }
                            else{
                                channel.close();
                                connection.close();
                                rabbit(factory);
                            }
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                }
                else{
                    senders.put(headers.get(SENDER_ID), true);

                    ObjectMapper objectMapper = new ObjectMapper();
                    try{
                        Message message = objectMapper.readValue(messageJson, Message.class);
                        System.out.println(message.toString());
                    }
                    catch (Exception e){
                        System.out.println(e.getMessage());
                    }
                }
            }
        };
        channel.basicConsume(QUEUE_NAME, true, deliverCallback, consumerTag -> { });
    }
    public static void main(String[] argv) throws Exception {


        ConnectionFactory factory = new ConnectionFactory();
        factory.setHost("192.168.43.40");

        factory.setPort(5672);
        factory.setUsername("szymek");
        factory.setPassword("szymek");
        rabbit(factory);
    }
}

