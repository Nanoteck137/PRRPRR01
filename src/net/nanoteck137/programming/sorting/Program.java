package net.nanoteck137.programming.sorting;

import java.util.Arrays;
import java.util.Random;

public class Program {

    public static void main(String[] args) {
        int[] array = new int[200];

        //NOTE: Fill the array with 200 random values
        for(int i = 0; i < array.length; i++) {
            array[i] = (int)(Math.random() * 100) + 1;
        }

        System.out.printf("Starting array: %s\n", Arrays.toString(array));

        int[] list = array.clone();
        long startTime = System.nanoTime();
        int numSwiches= BubbleSort.bubbleSort(list);
        long endTime = System.nanoTime();
        System.out.printf("Bubble Sort - Time Taken: %fms Num switches: %d\n\tResult: %s\n\n", (endTime - startTime) / 1000000.0f, numSwiches, Arrays.toString(list));

        list = array.clone();
        startTime = System.nanoTime();
        numSwiches = CocktailSort.cocktailSort(list);
        endTime = System.nanoTime();
        System.out.printf("Cocktail Sort - Time Taken: %fms Num switches: %d\n\tResult: %s\n\n", (endTime - startTime) / 1000000.0f, numSwiches, Arrays.toString(list));

        list = array.clone();
        startTime = System.nanoTime();
        numSwiches = SelectionSort.selectionSort(list);
        endTime = System.nanoTime();
        System.out.printf("Selection Sort - Time Taken: %fms Num switches: %d\n\tResult: %s\n\n", (endTime - startTime) / 1000000.0f, numSwiches, Arrays.toString(list));

        list = array.clone();
        startTime = System.nanoTime();
        numSwiches = InsertionSort.insertionSort(list);
        endTime = System.nanoTime();
        System.out.printf("Insertion Sort - Time Taken: %fms Num switches: %d\n\tResult: %s\n\n", (endTime - startTime) / 1000000.0f, numSwiches, Arrays.toString(list));
    }

}
