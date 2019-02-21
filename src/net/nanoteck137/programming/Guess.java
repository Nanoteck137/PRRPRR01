package net.nanoteck137.programming;

import java.io.*;
import java.util.Random;
import java.util.Scanner;

public class Guess {

    public static final int DIFFICULTY_EASY = 1;
    public static final int DIFFICULTY_NORMAL = 2;
    public static final int DIFFICULTY_HARD = 3;
    public static final int DIFFICULTY_SUPER_HARD = 4;

    public static int currentDifficulty = 0;
    public static int gameWon = 0;
    public static int totalGuesses = 0;
    public static int currentGameGuesses = 0;

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

    private static int getRandomValue(int difficulty) {
        int high = getDifficultyHigh(difficulty);
        int result = (int) (Math.random() * high);

        return result;
    }

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

    private static void saveProgress() {
        try {
            FileWriter fileWriter = new FileWriter("SaveState.txt");
            fileWriter.write(String.format("%d,%d", gameWon, totalGuesses));
            fileWriter.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private static void restoreProgress() {
        try {
            FileReader fileReader = new FileReader("SaveState.txt");
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

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        restoreProgress();

        int correctGuess = getCorrectGuess(scanner, true);

        boolean running = true;
        while(running)
        {
            System.out.printf("Make a guess: ");
            int guess = scanner.nextInt();
            System.out.println();

            totalGuesses++;
            currentGameGuesses++;

            if(guess > correctGuess) {
                System.out.println("High");
            } else if(guess < correctGuess) {
                System.out.println("Low");
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
                        correctGuess = getCorrectGuess(scanner, false);
                    } break;

                    case 2: {
                        correctGuess = getCorrectGuess(scanner, true);
                    } break;

                    default: {
                        saveProgress();
                        running = false;
                    } break;
                }

            }
        }

        scanner.close();
    }

}
