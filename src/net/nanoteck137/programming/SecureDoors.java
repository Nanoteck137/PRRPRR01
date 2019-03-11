package net.nanoteck137.programming;

import java.util.ArrayList;
import java.util.Scanner;

public class SecureDoors {

    public static void main(String[] args)
    {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());

        ArrayList<String> list = new ArrayList<>();

        while (n-- > 0)
        {
            String[] line = scanner.nextLine().split(" ");

            String command = line[0];
            String name = line[1];

            if(command.equals("entry"))
            {
                boolean found = false;
                for(int i = 0; i < list.size(); i++) {
                    if(list.get(i).equals(name)) {
                        found = true;
                        System.out.printf("%s entered (ANOMALY)\n", name);

                        break;
                    }
                }

                if(!found) {
                    list.add(name);
                    System.out.printf("%s entered\n", name);
                }
            } else if(command.equals("exit")) {
                boolean found = false;
                for(int i = 0; i < list.size(); i++) {
                    if(list.get(i).equals(name)) {
                        found = true;
                        list.remove(i);
                        System.out.printf("%s exited\n", name);
                        break;
                    }
                }

                if(!found) {
                    System.out.printf("%s exited (ANOMALY)\n", name);
                }
            }
        }
    }

}
