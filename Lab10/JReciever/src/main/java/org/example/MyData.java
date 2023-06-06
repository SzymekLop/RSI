package org.example;

import java.net.Inet4Address;
import java.net.InetAddress;
import java.net.NetworkInterface;
import java.net.SocketException;
import java.sql.SQLOutput;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.Enumeration;

public class MyData {

    public static void info() {
        System.out.println("Aleksandra Wolska, 251810");
        System.out.println("Szymon Łopuszyński, 260454");
        DateTimeFormatter dtf = DateTimeFormatter.ofPattern("M MMMM, H:m:s");
        LocalDateTime now = LocalDateTime.now();
        System.out.println(dtf.format(now));
        System.out.println(System.getProperty("java.version"));
        System.out.println(System.getProperty("user.name"));
        System.out.println(System.getProperty("os.name") + " " + System.getProperty("os.version"));
        try {
            Enumeration<NetworkInterface> networks = NetworkInterface.getNetworkInterfaces();
            while (networks.hasMoreElements()) {
                NetworkInterface network = networks.nextElement();
                Enumeration<InetAddress> addresses = network.getInetAddresses();
                if(network.getName().equals("wlan0")){
                    InetAddress ip = addresses.nextElement();
                    System.out.println(ip.getHostAddress());
                }
            }
        } catch (SocketException e) {
            e.printStackTrace();
        }
    }
}
