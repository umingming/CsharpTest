package kr.co.aim;

import java.io.File;
import java.io.FileOutputStream;
import java.util.Iterator;

import org.jdom2.Comment;
import org.jdom2.Document;
import org.jdom2.Element;
import org.jdom2.filter.ElementFilter;
import org.jdom2.input.SAXBuilder;
import org.jdom2.output.Format;
import org.jdom2.output.XMLOutputter;

/*
	XML Parser
	- XML 파일 객체화, 내용 출력, 수정
 */
public class Parser {
	private String path;
	private File file;
	private Document doc;
	private XMLOutputter xout;
	
	public Parser() throws Exception {
		parseFile();
	}
	
	public Parser(String path) throws Exception {
		this.path = path;
		this.file = new File(path);
		this.xout = new XMLOutputter();
		parseFile();
	}
	
	/*
		doc를 xml 파싱 값으로 초기화
	 */
	public void parseFile() throws Exception {
		if(file.exists()) {
			SAXBuilder builder = new SAXBuilder();
			this.doc = builder.build(path);
			System.out.println("Success to parse : " + file.getName());
			
		} else {
			System.out.println("Failure to parse : " + file.getName());
		}
	}
	
	/*
		콘솔에 내용 출력
	 */
	public void printFile() throws Exception {
		Format format = xout.getFormat();
		
		format.setLineSeparator("\r\n");
		format.setIndent("\t");
		format.setTextMode(Format.TextMode.TRIM);
		xout.setFormat(format);
		
		if(doc != null) {
			xout.output(doc, System.out);
			System.out.println("Success to print : " + file.getName());
			
		} else {
			System.out.println("Failure to print : " + file.getName());
		}
	}

	/*
		루트 내에서 태그 탐색해 해당하는 요소를 반환
	 */
	public Element navigateElement(Tag tag) {
		Iterator<Element> iter = doc.getDescendants(new ElementFilter(tag.getType()));
		
		while(iter.hasNext()) {
			Element descendant = (Element) iter.next();
			
			if(descendant.getAttributeValue("Name").equals(tag.getName())) {
				System.out.println("Success to navigate : " + tag.getName());
				return descendant;
			} 
		}
		System.out.println("Failure to navigate : " + tag.getName());
		return null;
	}
	
	/*
		요소 내에서 태그 탐색해 해당하는 요소를 반환함.
	 */
	public Element navigateElement(Element element, Tag tag) {
		if(element != null) {
			Iterator<Element> iter = element.getDescendants(new ElementFilter(tag.getType()));
			
			while(iter.hasNext()) {
				Element descendant = (Element) iter.next();
				
				if(descendant.getAttributeValue("Name").equals(tag.getName())) {
					System.out.println("Success to navigate : " + tag.getName());
					return descendant;
				}
			}
		}
		System.out.println("Failure to navigate : " + tag.getName());
		return null;
	}
	
	/*
		루트 내에서 태그를 탐색하고, 반환된 요소에서 또 태그를 탐색해 반환함.
	 */
	public Element navigateElement(Tag parent, Tag child) {
		Element element = navigateElement(parent);
		
		if(element != null) {
			Iterator<Element> iter = element.getDescendants(new ElementFilter(child.getType()));
			
			while(iter.hasNext()) {
				Element descendant = (Element) iter.next();
				
				if(descendant.getAttributeValue("Name").equals(child.getName())) {
					System.out.println("Success to navigate : " + child.getName());
					return descendant;
				}
			}
		}
		System.out.println("Failure to navigate : " + child.getName());
		return null;
	}

	/*
		태그 탐색 후 해당 요소를 카피함.
	 */
	public Element copyElement(Element element, Tag tag) {
		Element copy = navigateElement(element, tag).clone();

		if(copy != null) {
			copy.removeContent();
			
			String newVal = copy.getAttributeValue("Name") + "_APPEND";
			copy.setAttribute("Name", newVal);
			
			System.out.println("Success to copy : " + tag.getName());
			return copy;
		}
		System.out.println("Failure to copy : " + tag.getName());
		return null;
	}
	
	/*
		부모 태그로 요소 탐색 후 태그를 가진 자식을 생성함.
	 */
	public void createChild(Tag tagParent, Tag tagChild) { 
		Element parent = navigateElement(tagParent);
		
		if(parent != null) {
			Element child = new Element(tagChild.getType())
					.setAttribute("Name", tagChild.getName());
			parent.addContent(child);
			System.out.println("Success to create : " + tagChild.getName());
			
		} else {
			System.out.println("Failure to create : " + tagChild.getName());
		}
	}
	
	/*
		부모에 해당 태그 자식을 생성함.
	 */
	public void createChild(Element parent, Tag tagChild) { 
		if(parent != null) {
			Element child = new Element(tagChild.getType())
					.setAttribute("Name", tagChild.getName());
			parent.addContent(child);
			System.out.println("Success to create : " + tagChild.getName());
			
		} else {
			System.out.println("Failure to create : " + tagChild.getName());
		}
	}
	
	/*
		태그 탐색 후 해당 태그를 원하는 속성으로 수정함.
	 */
	public void modifyElement(Tag tag, String attr, String value) { 
		Element element = navigateElement(tag);
		
		if(element != null) {
			element.setAttribute(attr, value);
			System.out.println("Success to modify : " + tag.getName());
			
		} else {
			System.out.println("Filure to modify : " + tag.getName());
		}
	}
	
	/*
		해당 요소를 원하는 속성 값으로 수정함.
	 */
	public void modifyElement(Element element, String attr, String value) {
		if(element.getAttribute(attr) != null) {
			element.setAttribute(attr, value);
			System.out.println("Success to modify : " + element.getName());
			
		} else {
			System.out.println("Filure to modify : " + element.getName());
		}
	}

	/*
		부모 요소 내에서 태그 탐색해 원하는 속성으로 수정함.
	 */
	public void modifyElement(Element parent, Tag tag, String attr, String value) {
		Element element = navigateElement(parent, tag);
		
		if(element != null) {
			element.setAttribute(attr, value);
			System.out.println("Success to modify : " + tag.getName());
			
		} else {
			System.out.println("Filure to modify : " + tag.getName());
		}
	}
	
	/*
		부모 요소 내에서 태그 탐색해 주석 처리함.
	 */
	public void commentOutElement(Element parent, Tag tag) {
		Element child = navigateElement(parent, tag);
		
		if(child != null) {
			Comment comment = new Comment(xout.outputString(child));
			parent.setContent(parent.indexOf(child), comment);
			System.out.println("Success to toggle : " + tag.getName());
			
		} else {
			System.out.println("Filure to toggle : " + tag.getName());
		}
	}
	
	/*
		태그를 탐색해 주석 처리함.
	 */
	public void commentOutElement(Tag tag) {
		Element child = navigateElement(tag);
		
		if(child != null) {
			Element parent = child.getParentElement();
			Comment comment = new Comment(xout.outputString(child));
			parent.setContent(parent.indexOf(child), comment);
			System.out.println("Success to toggle : " + tag.getName());
			
		} else {
			System.out.println("Filure to toggle : " + tag.getName());
		}
	}
	
	/*
		태그 탐색해 삭제함.
	 */
	public void removeElement(Tag tag) {
		Element element = navigateElement(tag);
		
		if(element != null) {
			element.getParent().removeContent(element);
			System.out.println("Success to delete : " + tag.getName());
			
		} else {
			System.out.println("Filure to delete : " + tag.getName());
		}
	}
	
	/*
		새로운 경로에 저장
	 */
	public void saveAs(String name) throws Exception {
		if(doc != null) {
			String newFile = String.format("%s\\%s.xml"
											, file.getParent(), name);
			xout.output(doc, new FileOutputStream(newFile));
			System.out.println("Success to update : " + file.getName());
			
		} else {
			System.out.println("Failure to update : " + file.getName());
		}
	}
}