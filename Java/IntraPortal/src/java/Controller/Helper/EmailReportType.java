package Controller.Helper;

/**
 *
 * @author ASerdar
 */
public enum EmailReportType {

    TEXT(1),
    TEXT_FIRSTPAGE(2),
    TEXT_ALLPAGE(3);
    
    private int value;

    private EmailReportType(int value) {
        this.value = value;
    }

    public int getValue() {
        return value;
    }
}
