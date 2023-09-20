﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feature_sample
{
    internal class ExRef : ExBase
    {
        public class Hoge
        {
            public int value = 0;
        }

        public struct Foo
        {
            public int value;
        }

        Foo m_FooValue;
        public Foo fooValue => m_FooValue;
        public ref Foo refFooValue => ref m_FooValue;

        Hoge m_HogeValue = new Hoge();
        public Hoge hogeValue => m_HogeValue;

        int m_IntValue = 0;
        public int intValue => m_IntValue;

        string m_StrValue = "hoge";
        public string strValue => m_StrValue;

        public void Exec()
        {
            //readonlyなので代入はできない
            //value = 0;
            //strValue = "";

            //関数は使えるが、書き換えはされていない
            strValue.Insert(0, "piyo");
            Console.WriteLine($"strValue = {strValue}");

            //↓書き換えはできる
            hogeValue.value = 1;
            Console.WriteLine($"hogeValue.value = {hogeValue.value}");

            //↓できない
            //fooValue.value = 1;

            //↓参照なので、書き換えできる。
            refFooValue.value = 1;
            Console.WriteLine($"refFooValue.value = {refFooValue.value}");
        }
    }
}
