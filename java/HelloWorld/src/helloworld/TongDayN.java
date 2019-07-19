/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package helloworld;

/**
 *
 * @author thang
 */
public class TongDayN {

    /**
     *
     */
    public  int n;
    public TongDayN(int n){
        this.n=n;
    }
    public int TinhTong(){
        int tong=0;
        for (int i = 0; i < n; i++) {
            tong+=i;
        }
        return tong;
    }
}
