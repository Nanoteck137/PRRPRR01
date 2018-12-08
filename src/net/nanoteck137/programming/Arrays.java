package net.nanoteck137.programming;

import java.awt.*;

public class Arrays {

    private static final int[] numbers = {1,1,1,2,6,7,8,4,3,7,8,9,3,1,3,7,8,5,3,4,8,9,6,4,2,4,7,9,7,4,3,2,3,6,7,8,7,7,5,7,9,6,1,4,0,8,6,5,6,8,9,0,7,5,4,3,2,4,5,9,8,5,9,8,8,4,5,6,7,8,9,0,9,0,9,7,5,2,1,2,3,4,5,4,4,5,3,4,5,0,8,7,0,7,9,7,0,6,5,4,7};
    private static final String[] names = {"Crystal","Tam","Ed","Beulah","Daina","Benjamin","Kia","Clelia","Cassy","Gita","Celsa","Karoline","Talitha","Lewis","Betsy","Colin","Glendora","Carola","Rosalba","Jeanie","Yevette","Armand","Neal","Lilla","Dorethea","Delta","Maye","Nikita","Shoshana","Carola","Margie","Haywood","Venessa","Natacha","Gilbert","Kandi","Tyisha","Tammie","Blossom","Penney","Diana","Audrey","Willard","Zoraida","Drusilla","Jacquline","Cyndy","Janiece","Tressie","Kami","Lashanda","Leann","Tom","Santana","Junita","Gisela","Tom","Marquerite","Bryant","Lauralee","Yael","Kelle","Samantha","Tom","Meta","Lanette","Wanetta","Carola","Jana","Neal","Brady","Rigoberto","Felicia","Hellen","Georgeann","Carola","Isaias","Ellis","Roseanne","Lenard","Ela","Ophelia","Alesha","Mafalda","Flor","Kelsi","Autumn","Sondra","Pasty","Jacquelyne","Benjamin","Emmie","Mickie","Lang","Jamee","Felice","Daniella","Carola","Nathalie","Genevive"};

    public static void main(String[] args) {

        System.out.println("1: Hur många 7:or finns det i numbers?");
        System.out.printf("\tSvar: %d\n", searchForNumber(7));

        System.out.println("2: Hur många personer som heter Tom finns det i names?");
        System.out.printf("\tSvar: %d\n", searchForName("Tom"));

        System.out.println("3: Vilket nummer finns det flest respektive minst utav i numbers?");

        int[] result = searchMinMaxNumber();

        int maxNumber = result[0];
        int maxFreq = result[1];

        int minNumber = result[2];
        int minFreq = result[3];

        System.out.printf("\tSvar: %d finns det flest av med %dst och %d finns det minst av med %dst\n", maxNumber, maxFreq, minNumber, minFreq);

        System.out.println("4: På vilket index finns namnet Drusilla i names?");
        System.out.printf("\tSvar: %d\n", searchForNameIndex("Drusilla"));

        System.out.println("5: Vad är summan av alla jämna tal i numbers?");
        System.out.printf("\tSvar: %d\n", sumAllEvenNumbers());

        System.out.println("6: Hur många namn börjar på bokstaven L i names?");
        System.out.printf("\tSvar: %d\n", countNamesStartWith('L'));

    }

    private static int searchForNumber(int number) {
        int result = 0;
        for (int i = 0; i < numbers.length; i++) {
            if(numbers[i] == number)
                result++;
        }

        return result;
    }

    private static int searchForName(String name) {
        int result = 0;
        for (int i = 0; i < names.length; i++) {
            if(names[i].equals(name))
                result++;
        }

        return result;
    }

    private static int[] searchMinMaxNumber() {
        int[] freqList = new int[10];
        int[] indexList = new int[10];

        for(int i = 0; i < numbers.length; i++){
            freqList[numbers[i]] += 1;
        }

        for (int i = 0; i < indexList.length; i++) {
            indexList[i] = i;
        }

        //Bubble sort algorithm (https://brilliant.org/wiki/sorting-algorithms/)

        boolean stop = false;
        while(!stop) {
            int switches = 0;

            for (int i = 0; i < freqList.length; i++) {
                if (i < freqList.length - 1) {
                    int first = freqList[i];
                    int second = freqList[i + 1];

                    if (first > second) {
                        freqList[i] = second;
                        freqList[i + 1] = first;

                        int temp = indexList[i];
                        indexList[i] = indexList[i + 1];
                        indexList[i + 1] = temp;

                        switches++;
                    }
                }
            }

            if(switches == 0) {
                stop = true;
            }
        }

        int maxFreq = freqList[freqList.length - 1];
        int maxNumber = indexList[indexList.length - 1];

        int minFreq = freqList[0];
        int minNumber = indexList[0];

        return new int[] { maxNumber, maxFreq, minNumber, minFreq };
    }

    private static int searchForNameIndex(String name) {
        int result = 0;

        for (int i = 0; i < names.length; i++) {
            if(names[i].equals(name)) {
                result = i;
                break;
            }
        }
        
        return result;
    }

    private static int sumAllEvenNumbers() {
        int result = 0;

        for (int i = 0; i < numbers.length; i++) {
            if(numbers[i] % 2 == 0) {
                result += numbers[i];
            }
        }
        
        return result;
    }

    private static int countNamesStartWith(char c) {
        int result = 0;

        for (int i = 0; i < names.length; i++) {
            if(names[i].charAt(0) == c) {
                result++;
            }
        }
        
        return result;
    }

}
