package Controller.Helper;

/**
 *
 * @author ASerdar
 */
public enum DeliverType {
    FAX2FAX(0),
    FAX2EMAIL(1),
    BOTH(2);
 
    private int value;
    
    private DeliverType(int value) {
        this.value = value;
    }
    
    public int getValue() {
        return value;
    }
}

