package net.nanoteck137.programming;

import java.util.Scanner;

public class SwitchCase {

    private static void printMenu() {
        System.out.println("1 - Low Level Programming languages");
        System.out.println("2 - High Level Programming languages");
        System.out.println("3 - Best Programming languages");
        System.out.println("4 - Worst Level Programming languages");
        System.out.println("5 - Quit");
        System.out.println();
    }

    private static boolean processInput(int option) {
        switch(option) {
            case 1:
                System.out.println("Result: ");
                System.out.println("\tC");
                System.out.println("\tC++");
                System.out.println("\tRust");
                System.out.println();
                return true;
            case 2:
                System.out.println("Result: ");
                System.out.println("\tJava");
                System.out.println("\tC#");
                System.out.println();
                return true;
            case 3:
                System.out.println("Result: ");
                System.out.println("\tC#");
                System.out.println("\tC++");
                System.out.println("\tC");
                System.out.println();
                return true;
            case 4:
                System.out.println("Result: ");
                System.out.println("\tJava");
                System.out.println();
                return true;
            case 5:
                //Case 5 exit the program, return false to exit the program
                return false;
            case 25:
                System.out.println("Secret Maxi");
                return true;
            default:
                System.out.println("Invalid option");
                return true;
        }

    }

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        boolean running = true;
        while(running) {
            printMenu();
            int option = scanner.nextInt();
            running = processInput(option);
        }


    }

}
