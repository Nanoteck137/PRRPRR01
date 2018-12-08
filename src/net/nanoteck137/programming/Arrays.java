package net.nanoteck137.programming;

public class Arrays {

    //A private array with some numbers
    private static final int[] numbers = {1,1,1,2,6,7,8,4,3,7,8,9,3,1,3,7,8,5,3,4,8,9,6,4,2,4,7,9,7,4,3,2,3,6,7,8,7,7,5,7,9,6,1,4,0,8,6,5,6,8,9,0,7,5,4,3,2,4,5,9,8,5,9,8,8,4,5,6,7,8,9,0,9,0,9,7,5,2,1,2,3,4,5,4,4,5,3,4,5,0,8,7,0,7,9,7,0,6,5,4,7};

    //A private array with some names
    private static final String[] names = {"Crystal","Tam","Ed","Beulah","Daina","Benjamin","Kia","Clelia","Cassy","Gita","Celsa","Karoline","Talitha","Lewis","Betsy","Colin","Glendora","Carola","Rosalba","Jeanie","Yevette","Armand","Neal","Lilla","Dorethea","Delta","Maye","Nikita","Shoshana","Carola","Margie","Haywood","Venessa","Natacha","Gilbert","Kandi","Tyisha","Tammie","Blossom","Penney","Diana","Audrey","Willard","Zoraida","Drusilla","Jacquline","Cyndy","Janiece","Tressie","Kami","Lashanda","Leann","Tom","Santana","Junita","Gisela","Tom","Marquerite","Bryant","Lauralee","Yael","Kelle","Samantha","Tom","Meta","Lanette","Wanetta","Carola","Jana","Neal","Brady","Rigoberto","Felicia","Hellen","Georgeann","Carola","Isaias","Ellis","Roseanne","Lenard","Ela","Ophelia","Alesha","Mafalda","Flor","Kelsi","Autumn","Sondra","Pasty","Jacquelyne","Benjamin","Emmie","Mickie","Lang","Jamee","Felice","Daniella","Carola","Nathalie","Genevive"};

    /**
     * Main method of the program
     * @param args The command line arguments passed to the program
     */
    public static void main(String[] args) {

        System.out.println("1: Hur många 7:or finns det i numbers?");
        System.out.printf("\tSvar: %d\n", countNumber(7));

        System.out.println("2: Hur många personer som heter Tom finns det i names?");
        System.out.printf("\tSvar: %d\n", countName("Tom"));

        System.out.println("3: Vilket nummer finns det flest respektive minst utav i numbers?");

        int[] result = searchMinMaxNumber();

        int minNumber = result[0];
        int minFreq = result[1];

        int maxNumber = result[2];
        int maxFreq = result[3];

        System.out.printf("\tSvar: %d finns det minst av med %dst och %d finns det flex av med %dst\n", minNumber, minFreq, maxNumber, maxFreq);

        System.out.println("4: På vilket index finns namnet Drusilla i names?");
        System.out.printf("\tSvar: %d\n", searchForNameIndex("Drusilla"));

        System.out.println("5: Vad är summan av alla jämna tal i numbers?");
        System.out.printf("\tSvar: %d\n", sumAllEvenNumbers());

        System.out.println("6: Hur många namn börjar på bokstaven L i names?");
        System.out.printf("\tSvar: %d\n", countNamesStartWith('L'));

        System.out.println("7: Hur många namn är fem bokstäver långa i names?");
        System.out.printf("\tSvar: %d\n", countNamesWithLength(5));

        System.out.println("8: Hur många finns det av varje tal i numbers?");
        System.out.print("\tSvar: ");
        int[] freqList = generateListWithFreqForNumbers();
        for (int i = 0; i < freqList.length; i++) {
            System.out.printf("%d: %dst", i, freqList[i]);

            if(i < freqList.length - 1) {
                System.out.print(", ");
            }
        }
        System.out.print("\n");

        System.out.println("9: Hur många unika namn finns det i names?");
        System.out.printf("\tSvar: %d\n", uniqueNames());
    }

    /**
     * Counts the number of occurrences in the numbers array
     * @param number The number we are counting
     * @return Returns number of occurrences
     */
    private static int countNumber(int number) {
        int result = 0;

        for (int i = 0; i < numbers.length; i++) {
            if(numbers[i] == number)
                result++;
        }

        return result;
    }

    /**
     * Counts the number of occurrences in the names array
     * @param name The name we are counting
     * @return Returns number of occurrences
     */
    private static int countName(String name) {
        int result = 0;

        for (int i = 0; i < names.length; i++) {
            if(names[i].equals(name))
                result++;
        }

        return result;
    }

    /**
     * Searches for the lowest and highest number of occurrences in the number array
     * @return An array with the information (Format: Min number, Min frequency, Max number, Max frequency)
     */
    private static int[] searchMinMaxNumber() {
        int[] freqList = generateListWithFreqForNumbers();

        int[] indexList = new int[10];
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

            if(switches == 0)
                stop = true;
        }

        int minFreq = freqList[0];
        int minNumber = indexList[0];

        int maxFreq = freqList[freqList.length - 1];
        int maxNumber = indexList[indexList.length - 1];

        return new int[] { minNumber, minFreq, maxNumber, maxFreq };
    }

    /**
     * Searches for a name in the names array
     * @param name The name we are searching for
     * @return Returns the index where the name occurred in the names array
     */
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

    /**
     * Sums all the even numbers in the numbers array
     * @return Returns the sum
     */
    private static int sumAllEvenNumbers() {
        int result = 0;

        for (int i = 0; i < numbers.length; i++) {
            if(numbers[i] % 2 == 0)
                result += numbers[i];
        }
        
        return result;
    }

    /**
     * Counts the names that start with a specified character
     * @param c The character the name needs to start with
     * @return Returns the number of occurrences
     */
    private static int countNamesStartWith(char c) {
        int result = 0;

        for (int i = 0; i < names.length; i++) {
            if(names[i].charAt(0) == c)
                result++;
        }
        
        return result;
    }

    /**
     * Counts the names that are a specified length
     * @param length The length that the name need to have
     * @return Returns the number of occurrences
     */
    private static int countNamesWithLength(int length) {
        int result = 0;

        for (int i = 0; i < names.length; i++) {
            if(names[i].length() == length)
                result++;
        }

        return result;
    }

    /**
     * Generates a list with how frequent numbers occur
     * @return Returns a list with the frequencies
     */
    private static int[] generateListWithFreqForNumbers() {
        int[] result = new int[10];

        for (int i = 0; i < numbers.length; i++){
            result[numbers[i]]++;
        }

        return result;
    }

    /**
     * Searches the names array for all unique names
     * @return Returns the number of unique names
     */
    private static int uniqueNames() {
        int result = 0;

        for(int i = 0; i < names.length; i++) {
            int j;

            for (j = 0; j < names.length; j++) {
                if(names[i].equals(names[j])) {
                    break;
                }
            }

            if (i == j) {
                result++;
            }
        }

        return result;
    }

}
