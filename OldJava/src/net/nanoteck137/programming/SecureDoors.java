package net.nanoteck137.programming;

import java.util.ArrayList;
import java.util.Scanner;

public class SecureDoors {

    /**
     * Main function of the program
     * @param args Command line arguments for the program
     */
    public static void main(String[] args)
    {
        //NOTE(patrik): Scanner for input
        Scanner scanner = new Scanner(System.in);
        int numLogs = Integer.parseInt(scanner.nextLine());

        //NOTE(patrik): List of the persons that entered the system
        ArrayList<String> list = new ArrayList<>();

        while (numLogs-- > 0)
        {
            //NOTE(patrik): Splits the input string to get a command and a name
            String[] line = scanner.nextLine().split(" ");

            String command = line[0];
            String name = line[1];

            //NOTE(patrik): If the command is "entry" then add them to the list and check if they are already in the system then print ANOMALY
            if(command.equals("entry"))
            {
                boolean found = false;
                //NOTE(patrik): Loop through the list and check if the person is in the list
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

            //NOTE(patrik): If the command is "exit" then remove the person from the list
            } else if(command.equals("exit")) {
                boolean found = false;
                //NOTE(patrik): Loop through the list and check if the person is in the list
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
