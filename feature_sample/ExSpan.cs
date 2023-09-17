using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feature_sample
{
    internal static class ExSpan
    {
        public static void Exec()
        {
            var array = new int[8];

            for (int idx = 0; idx < array.Length; idx++) {
                array[idx] = idx;
            }

            // 配列の、2番目(0 始まりなので3要素目)から、3要素分の範囲
            var span = new Span<int>(array, 2, 3);

            for (int i = 0; i < span.Length; i++) {
                span[i] = (i + 1) * 10;
            }

            foreach (var x in array) {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            span = array.AsSpan().Slice(5, 2);

            for (int i = 0; i < span.Length; i++) {
                span[i] = (i + 1) * 100;
            }

            foreach (var x in array) {
                Console.WriteLine(x);
            }
            Console.WriteLine();
        }
    }
}
