package Controller.BussinesLayer;

import Model.MainSlider;
import java.io.File;
import java.util.ArrayList;
import javax.faces.context.FacesContext;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerException;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;
import org.w3c.dom.Attr;
import org.w3c.dom.Document;
import org.w3c.dom.Element;

/**
 *
 * @author asay
 */
public class SliderTool {

    public void refreshSlider(ArrayList<MainSlider> list) {
        try {

            DocumentBuilderFactory docFactory = DocumentBuilderFactory.newInstance();
            DocumentBuilder docBuilder = docFactory.newDocumentBuilder();

            // root elements
            Document doc = docBuilder.newDocument();
            Element rootElement = doc.createElement("Piecemaker");
            doc.appendChild(rootElement);

            // settings elements
            Element settings = doc.createElement("Settings");
            rootElement.appendChild(settings);


            // imageWidth elements
            Element imageWidth = doc.createElement("imageWidth");
            imageWidth.appendChild(doc.createTextNode("700"));
            settings.appendChild(imageWidth);

            // imageHeight elements
            Element imageHeight = doc.createElement("imageHeight");
            imageHeight.appendChild(doc.createTextNode("350"));
            settings.appendChild(imageHeight);

            // segments elements
            Element segments = doc.createElement("segments");
            segments.appendChild(doc.createTextNode("7"));
            settings.appendChild(segments);

            // tweenTime elements
            Element tweenTime = doc.createElement("tweenTime");
            tweenTime.appendChild(doc.createTextNode("1.2"));
            settings.appendChild(tweenTime);

            // tweenDelay elements
            Element tweenDelay = doc.createElement("tweenDelay");
            tweenDelay.appendChild(doc.createTextNode("0.1"));
            settings.appendChild(tweenDelay);

            // tweenType elements
            Element tweenType = doc.createElement("tweenType");
            tweenType.appendChild(doc.createTextNode("easeInOutBack"));
            settings.appendChild(tweenType);

            // zDistance elements
            Element zDistance = doc.createElement("zDistance");
            zDistance.appendChild(doc.createTextNode("0"));
            settings.appendChild(zDistance);

            // expand elements
            Element expand = doc.createElement("expand");
            expand.appendChild(doc.createTextNode("20"));
            settings.appendChild(expand);

            // innerColor elements
            Element innerColor = doc.createElement("innerColor");
            innerColor.appendChild(doc.createTextNode("0x111111"));
            settings.appendChild(innerColor);

            // textBackground elements
            Element textBackground = doc.createElement("textBackground");
            textBackground.appendChild(doc.createTextNode("0x0064C8"));
            settings.appendChild(textBackground);

            // shadowDarkness elements
            Element shadowDarkness = doc.createElement("shadowDarkness");
            shadowDarkness.appendChild(doc.createTextNode("100"));
            settings.appendChild(shadowDarkness);

            // textDistance elements
            Element textDistance = doc.createElement("textDistance");
            textDistance.appendChild(doc.createTextNode("25"));
            settings.appendChild(textDistance);

            // autoplay elements
            Element autoplay = doc.createElement("autoplay");
            autoplay.appendChild(doc.createTextNode("12"));
            settings.appendChild(autoplay);

            for (MainSlider item : list) {

                // Image elements
                Element Image = doc.createElement("Image");
                rootElement.appendChild(Image);
                Image.setAttribute("Filename", item.getPicture());

                Element Text = doc.createElement("Text");
                Image.appendChild(Text);

                // headline elements
                Element headline = doc.createElement("headline");
                headline.appendChild(doc.createTextNode(item.getTitle()));
                Text.appendChild(headline);

                // break elements
                Element testbreak = doc.createElement("break");
                testbreak.appendChild(doc.createTextNode(""));
                Text.appendChild(testbreak);

                // paragraph elements
                Element paragraph = doc.createElement("paragraph");
                paragraph.appendChild(doc.createTextNode(item.getDescription()));
                Text.appendChild(paragraph);

                // inline elements
//                Element inline = doc.createElement("inline");
//                inline.appendChild(doc.createTextNode(item.getDescription()));
//                Text.appendChild(inline);
            }
            
            String path = FacesContext.getCurrentInstance().getExternalContext().getRealPath("/");

            // write the content into xml file
            TransformerFactory transformerFactory = TransformerFactory.newInstance();
            Transformer transformer = transformerFactory.newTransformer();
            DOMSource source = new DOMSource(doc);
            StreamResult result = new StreamResult(new File(path+"/piecemakerXML.xml"));

            // Output to console for testing
            // StreamResult result = new StreamResult(System.out);

            transformer.transform(source, result);

            // System.out.println("File saved!");

        } catch (ParserConfigurationException pce) {
            pce.printStackTrace();
        } catch (TransformerException tfe) {
            tfe.printStackTrace();
        }

    }
}
