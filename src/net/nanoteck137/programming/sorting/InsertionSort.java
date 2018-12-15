package net.nanoteck137.programming.sorting;

public class InsertionSort {

    /**
     * Sorts the list with the Bubble Sort algorithm
     * @param list The list to be sorted NOTE: passed as a reference
     */
    public static void insertionSort(int[] list) {
        for (int i = 1; i < list.length; i++) {
            int current = list[i];
            int lastIndex = i - 1;

            while (lastIndex >= 0 && list[lastIndex] > current) {
                list[lastIndex + 1] = list[lastIndex];
                lastIndex--;
            }
            list[lastIndex + 1] = current;
        }
    }

}
