package net.nanoteck137.programming.sorting;

public class BubbleSort {

    /**
     * Sorts the list with the Bubble Sort algorithm
     * @param list The list to be sorted NOTE: passed as a reference
     */
    public static int bubbleSort(int[] list) {
        int result = 0;

        boolean stop = false;
        while(!stop) {
            int switches = 0;
            for(int i = 0; i < list.length - 1; i++) {
                if(list[i] > list[i + 1]) {
                    int temp = list[i];
                    list[i] = list[i + 1];
                    list[i + 1] = temp;

                    switches++;
                    result++;
                }
            }

            if(switches == 0)
                stop = true;
        }

        return result;
    }

}
