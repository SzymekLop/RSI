import java.util.*;

public class VectorComp {

    public static boolean compareVector(){

        MyData.info();
        Object[] objs = {"string", 1, 1.5};
        Vector<Object> vector = new Vector<>(List.of(objs));

        for(Object o : vector){
            System.out.println(o);
        }

        Vector<Object> myVector = new Vector<>();

        Scanner scn = new Scanner(System.in);

        myVector.add(scn.next());
        myVector.add(scn.nextInt());
        myVector.add(scn.nextDouble());

        return vector.equals(myVector);
    }
}
