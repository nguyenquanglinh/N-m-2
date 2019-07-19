/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package helloworld;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.nio.file.Files;
import java.util.List;

/**
 *
 * @author thang
 */
public class FileString {

    private final String Path;
    public  FileString(String path){
        this.Path=path;
    }
    public List<String> OpenFile(String fileName) throws IOException {
        File f;
        f = new File(Path+fileName);
        List<String> lines ;
        lines= Files.readAllLines(f.toPath());
        return lines;
    }
    public  void WriteFile(String fileName,String line){
        try
        {
            File f;
            f=new File(Path+ fileName);
            System.out.println("path :"+f.toPath());
            try (FileWriter fw = new FileWriter(f) //the true will append the new data
            ) {
                fw.write(line);//appends the string to the file
            } //appends the string to the file
        }
        catch(IOException ioe)
        {
            System.err.println("IOException: " + ioe.getMessage());
        }
      
    }
}
