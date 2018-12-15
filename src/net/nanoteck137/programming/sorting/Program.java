package net.nanoteck137.programming.sorting;

import java.util.Arrays;
import java.util.Random;

public class Program {

    public static void main(String[] args) {
        int[] array = new int[200];

        for(int i = 0; i < array.length; i++) {
            array[i] = (int)(Math.random() * 100) + 1;
        }

        System.out.printf("Starting array: %s\n", Arrays.toString(array));

        int[] list = array.clone();
        long startTime = System.nanoTime();
        BubbleSort.bubbleSort(list);
        long endTime = System.nanoTime();
        System.out.printf("Bubble Sort - Time Taken: %fms\n\tResult: %s\n\n", (endTime - startTime) / 1000000.0f, Arrays.toString(list));

        list = array.clone();
        startTime = System.nanoTime();
        CocktailSort.cocktailSort(list);
        endTime = System.nanoTime();
        System.out.printf("Cocktail Sort - Time Taken: %fms\n\tResult: %s\n\n", (endTime - startTime) / 1000000.0f, Arrays.toString(list));

        list = array.clone();
        startTime = System.nanoTime();
        SelectionSort.selectionSort(list);
        endTime = System.nanoTime();
        System.out.printf("Selection Sort - Time Taken: %fms\n\tResult: %s\n\n", (endTime - startTime) / 1000000.0f, Arrays.toString(list));

        list = array.clone();
        startTime = System.nanoTime();
        InsertionSort.insertionSort(list);
        endTime = System.nanoTime();
        System.out.printf("Insertion Sort - Time Taken: %fms\n\tResult: %s\n\n", (endTime - startTime) / 1000000.0f, Arrays.toString(list));
    }

}
