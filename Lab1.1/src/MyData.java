import java.net.InetAddress;
import java.net.UnknownHostException;
import java.time.LocalDateTime;
import java.time.chrono.ChronoLocalDateTime;
import java.time.format.DateTimeFormatter;
import java.time.format.TextStyle;
import java.util.Date;
import java.util.Locale;

public class MyData {

    public static void info(){

        System.out.println("Aleksandra Wolska, 251810");
        System.out.println("Szymon Lopuszynski, 260454");
        LocalDateTime date = LocalDateTime.now();
        System.out.print(date.format(DateTimeFormatter.ofPattern("dd ")));
        System.out.print(date.getMonth().getDisplayName(TextStyle.FULL, Locale.ENGLISH) + ", ");
        System.out.println(date.format(DateTimeFormatter.ofPattern("HH:mm:ss")));

        System.out.println(System.getProperty("java.version"));
        System.out.println(System.getProperty("user.name"));
        System.out.println(System.getProperty("os.name"));

        InetAddress host = null;
        try {
            host = InetAddress.getLocalHost();
        } catch (UnknownHostException e) {
            throw new RuntimeException(e);
        }
        System.out.println(host.getHostAddress());

    }
}
