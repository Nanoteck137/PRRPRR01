package net.nanoteck137.programming;

import java.io.*;
import java.util.Scanner;

public class Guess {

    //NOTE(patrik):
    public static final String SAVE_STATE_FILE = "SaveState.txt";

    public static final int DIFFICULTY_EASY = 1;
    public static final int DIFFICULTY_NORMAL = 2;
    public static final int DIFFICULTY_HARD = 3;
    public static final int DIFFICULTY_SUPER_HARD = 4;

    public static int currentDifficulty = 0;
    public static int gameWon = 0;
    public static int totalGuesses = 0;
    public static int currentGameGuesses = 0;

    /**
     * Returns the highest possible random value based on the difficulty
     * @param difficulty The difficulty chosen
     * @return
     */
    private static int getDifficultyHigh(int difficulty) {
        int result = 100;

        switch(difficulty) {
            case DIFFICULTY_EASY: {
                result = 20;
            } break;

            case DIFFICULTY_NORMAL:{
                result = 60;
            } break;

            case DIFFICULTY_HARD: {
                result = 120;
            } break;

            case DIFFICULTY_SUPER_HARD: {
                result = 360;
            } break;
        }

        return result;
    }

    /**
     * Helper method to get a random value based on the difficulty
     * @param difficulty
     * @return
     */
    private static int getRandomValue(int difficulty) {
        int high = getDifficultyHigh(difficulty);
        int result = (int) (Math.random() * high);

        return result;
    }

    /**
     * Returns the correct guess number the computer generated and gives the user a choice of the difficulty
     * @param scanner The scanner in use
     * @param newDifficulty If there should be a new difficulty
     * @return
     */
    private static int getCorrectGuess(Scanner scanner, boolean newDifficulty) {
        if(newDifficulty) {
            System.out.println("Difficulty: ");
            System.out.printf("\tEasy: %d\n", DIFFICULTY_EASY);
            System.out.printf("\tNormal: %d\n", DIFFICULTY_NORMAL);
            System.out.printf("\tHard: %d\n", DIFFICULTY_HARD);
            System.out.printf("\tSuper Hard: %d\n", DIFFICULTY_SUPER_HARD);

            currentDifficulty = scanner.nextInt();
        }

        int correctGuess = getRandomValue(currentDifficulty);

        return correctGuess;
    }

    /**
     * Saves the progress to a file
     */
    private static void saveProgress() {
        try {
            FileWriter fileWriter = new FileWriter(SAVE_STATE_FILE);
            fileWriter.write(String.format("%d,%d", gameWon, totalGuesses));
            fileWriter.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    /**
     * Restores the progress from a file
     */
    private static void restoreProgress() {
        try {
            FileReader fileReader = new FileReader(SAVE_STATE_FILE);
            BufferedReader reader = new BufferedReader(fileReader);

            String line = reader.readLine();
            String[] values = line.split(",");

            gameWon = Integer.parseInt(values[0]);
            totalGuesses = Integer.parseInt(values[1]);

            System.out.println("Old game stats:");
            System.out.printf("\tGames won: %d\n", gameWon);
            System.out.printf("\tTotal guesses: %d\n", totalGuesses);
            System.out.println();

            reader.close();
            fileReader.close();
        } catch (IOException e) {
            if(e instanceof FileNotFoundException) {
                System.out.println("Creating a new session");
            } else {
                e.printStackTrace();
            }
        }
    }

    /**
     * Main method for the program
     * @param args Command line arguments
     */
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        //NOTE(patrik): Restore the progress in the beginning of the program
        restoreProgress();

        int correctGuess = getCorrectGuess(scanner, true);

        boolean running = true;
        while(running) {
            System.out.print("Make a guess: ");

            int guess = 0;
            try {
                guess = scanner.nextInt();
            } catch(Exception exception) {
                //NOTE(patrik): If the user types in something that's not a number the code below will execute
                System.out.println("Type a whole number");
                scanner.next();
                continue;
            }
            System.out.println();

            totalGuesses++;
            currentGameGuesses++;

            //NOTE(patrik):
            if(guess > correctGuess) {
                System.out.println("Too high");
            } else if(guess < correctGuess) {
                System.out.println("Too low");
            } else {
                System.out.println("-----------");
                System.out.println("Correct");
                System.out.println("-----------");

                gameWon++;

                System.out.println("Statistics");
                System.out.printf("\tGame Won: %d\n", gameWon);
                System.out.printf("\tTotal Guesses: %d\n", totalGuesses);
                System.out.printf("\tCurrent Game Guesses: %d\n", currentGameGuesses);

                currentGameGuesses = 0;

                System.out.println("1: Play again with same difficulty");
                System.out.println("2: New difficulty");
                System.out.println("3: Quit");

                int choice = scanner.nextInt();
                switch(choice) {
                    case 1: {
                        //NOTE(patrik): If the player wants to play again with the same difficulty
                        correctGuess = getCorrectGuess(scanner, false);
                    } break;

                    case 2: {
                        //NOTE(patrik): If the player wants to play again with the a different difficulty
                        correctGuess = getCorrectGuess(scanner, true);
                    } break;

                    default: {
                        //NOTE(patrik): Quit the program and save the progress
                        saveProgress();
                        running = false;
                    } break;
                }

            }
        }

        //NOTE(patrik): The scanner needs to be closed
        scanner.close();
    }

}
