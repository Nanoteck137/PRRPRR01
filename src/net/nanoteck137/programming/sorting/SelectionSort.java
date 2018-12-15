package net.nanoteck137.programming.sorting;

public class SelectionSort {

    /**
     * Sorts the list with the Bubble Sort algorithm
     * @param list The list to be sorted NOTE: passed as a reference
     */
    public static void selectionSort(int[] list) {
        for (int i = 0; i < list.length - 1; i++) {
            int minIndex = i;

            for (int j = i + 1; j < list.length; j++) {
                if (list[j] < list[minIndex])
                    minIndex = j;
            }

            int temp = list[i];
            list[i] = list[minIndex];
            list[minIndex] = temp;
        }
    }


}
