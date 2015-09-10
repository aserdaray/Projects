package Controller.Helper;

/**
 *
 * @author ASerdar
 */
public enum FaxReportType {
    TEXT(1),
    TEXT_FIRSTPAGE(2);
    
 
    private int value;
    
    private FaxReportType(int value) {
        this.value = value;
    }
    
    public int getValue() {
        return value;
    }
}

