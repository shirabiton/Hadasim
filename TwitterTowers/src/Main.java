import java.util.Scanner;

public class Main {

    public static void printTriangularRow(int asterisks, int width) {
        int i;

        // רווחים לפני הכוכביות
        for (i = 0; i < (width - asterisks) / 2; i++) {
            System.out.print(" ");
        }

        // הכוכביות
        for (i = 0; i < asterisks; i++) {
            System.out.print("*");
        }

        // רווחים לאחר הכוכביות
        for (i = 0; i < (width - asterisks) / 2; i++) {
            System.out.print(" ");
        }

        System.out.println();
    }

    public static void printTriangular(int length, int width) {
        int i,
                numOfAsterisks = 1;  // מספר הכוכביות ההתחלתי

        // מקרה קצה - הדפסה נפרדת
        if(width<=3){
            for(i=0; i<length-1; i++){
                printTriangularRow(numOfAsterisks, width);
            }
            if(width>1){
                numOfAsterisks+=2;
            }
        }
        else {
            int odds = (width - 2) / 2,  // מספר המספרים האי-זוגיים בטווח width - 1 לא כולל
                    all = (length - 2) / odds,  // מספר הפעמים הרצופות שתחזור על עצמה שורה של מספר אי-זוגי של כוכביות
                    more = (length - 2) % odds;  // מספר השורות הנוספות, השארית שתתנקז למספר הכוכביות בשורה האי-זוגי הקטן

            // הדפסת השורה הראשונה + הרווחים
            printTriangularRow(numOfAsterisks, width);

            // הדפסת שאר השורות
            while (true) {
                numOfAsterisks += 2; //  כך יודפס תמיד מספר אי-זוגי של כוכביות בשורה
                if (numOfAsterisks >= width) {
                    break;
                }
                for (i = 0; i < all + more; i++) {
                    printTriangularRow(numOfAsterisks, width);
                }
                more = 0;
            }
        }
            // הדפסת השורה האחרונה
            printTriangularRow(numOfAsterisks, width);
    }

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);

        int option, length, width, triangularOption;

        while (true) {
            System.out.println("Choose a shape for the tower:\n1 - rectangle\n2 - triangular\n3 - exit");
            option = in.nextInt();
            if (option == 3) {
                System.out.println("Bye");
                break;
            }
            System.out.println("Enter the shape's length");
            length = in.nextInt();
            System.out.println("Enter the shape's width");
            width = in.nextInt();

            if (option == 1) { // מלבן או ריבוע
                if (Math.abs(length - width) > 5) {
                    System.out.println("The area of the shape: " + length * width);
                } else {
                    System.out.println("The perimeter of the shape: " + 2 * (length + width));
                }
            } else if (option == 2) { // משולש
                System.out.println("Select an option:\n1 - calculate the perimeter of the triangle\n2 - the triangle print");
                triangularOption = in.nextInt();
                if (triangularOption == 1) {
                    // נגיע לאורך שוק של המשולש ע"י משפט פיתגורס, כי גובהו של משולש שווה שוקיים הוא גם תיכון, ואנך לבסיס
                    // לכן, נבצע משפט פיתגורס כך ששני הניצבים הם חצי מהבסיס (הרוחב) וגובה המשולש. כך נגיע ליתר המשולש ישר הזווית-השוק
                    // כעת נחשב בקלות את היקף המשולש, כי יש לנו את בסיס המשולש, ואורך שני השוקיים (משו"ש)
                    System.out.println("The perimeter of the triangle: " + (width + 2 * (Math.sqrt(Math.pow((double) width / 2, 2) + Math.pow(length, 2)))));
                } else {
                    if (width % 2 == 0 || width > (length * 2 + 1)) {
                        System.out.println("The triangle cannot be printed");
                    } else {
                        printTriangular(length, width);
                    }
                }

            }
        }
    }


}
