package net.nanoteck137.programming.sorting;

public class BubbleSort {

    public static void bubbleSort(int[] list) {
        boolean stop = false;
        while(!stop) {
            int switches = 0;
            for(int i = 0; i < list.length - 1; i++) {
                if(list[i] > list[i + 1]) {
                    int temp = list[i];
                    list[i] = list[i + 1];
                    list[i + 1] = temp;

                    switches++;
                }
            }

            if(switches == 0)
                stop = true;
        }
    }

}
