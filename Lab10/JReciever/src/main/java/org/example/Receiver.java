package org.example;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.rabbitmq.client.Channel;
import com.rabbitmq.client.Connection;
import com.rabbitmq.client.ConnectionFactory;
import com.rabbitmq.client.DeliverCallback;

import java.nio.charset.StandardCharsets;
import java.util.HashMap;
import java.util.Scanner;

public class Receiver {

    private final static String QUEUE_NAME = "hello-world";
    private static final String MESSAGE_END = "KONIEC";
    private static final String SENDER_ID = "senderId";
    public static void main(String[] argv) throws Exception {
        String choice = "again";

        while (choice.equals("again")){
            ConnectionFactory factory = new ConnectionFactory();
            factory.setHost("localhost");

            // factory.setUsername("guest");
            // factory.setPassword("guest");

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
                        if(senders.values().stream().noneMatch(value -> value)){
                            try {
                                channel.close();
                                connection.close();
                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                        }
                    }
                    else{
                        senders.put(headers.get(SENDER_ID), true);

                        ObjectMapper objectMapper = new ObjectMapper();
                        Message message = objectMapper.readValue(messageJson, Message.class);

                        System.out.println("- Wiadomość:\n   " + message.toString());
                    }
                }
            };
            channel.basicConsume(QUEUE_NAME, true, deliverCallback, consumerTag -> { });
            Scanner scn = new Scanner(System.in);
            System.out.println("Wpisz \"again\" aby ponowić, cokolwiek aby zakończyć");
            choice = scn.nextLine();
        }

    }
}

