package net.nanoteck137.programming.sorting;

public class CocktailSort {

    public static void cocktailSort(int[] list) {
        boolean swapped = true;

        while (swapped) {
            swapped = false;

            for (int i = 0; i < list.length - 1; ++i) {
                if (list[i] > list[i + 1]) {
                    int temp = list[i];
                    list[i] = list[i + 1];
                    list[i + 1] = temp;
                    swapped = true;
                }
            }

            if (!swapped)
                break;

            swapped = false;

            for (int i = list.length - 2; i >= 0; --i) {
                if (list[i] > list[i + 1]) {
                    int temp = list[i];
                    list[i] = list[i + 1];
                    list[i + 1] = temp;
                    swapped = true;
                }
            }
        }
    }


}
