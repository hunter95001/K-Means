using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Means.Processing
{
    class Pretreatment
    {
        Bitmap bitmap;
        int[,,] color; //R = 0,x,y 
                       //G = 1,x,y 
                       //B = 2,x,y

        public Pretreatment(Bitmap orignalBitamp)
        {
            this.bitmap = orignalBitamp;
            color = new int[3, orignalBitamp.Width, orignalBitamp.Height];

            for (int x = 0; x < orignalBitamp.Width; x++)
                for (int y = 0; y < orignalBitamp.Height; y++)
                {
                    color[0, x, y] = orignalBitamp.GetPixel(x, y).R;
                    color[1, x, y] = orignalBitamp.GetPixel(x, y).G;
                    color[2, x, y] = orignalBitamp.GetPixel(x, y).B;
                }
        }

        #region Gray
        /* 
        Gray 
        3차원의 RGB값을 한계의 값으로 바꿔서 처리의 효율성을 높이기 위한 작업으로
        R = G = B 값이 전부 같다
        
        방법은 3가지가 있으나
        G,B 값을 -> R값으로 처리해주는 기법을 사용한다.
        */
        public void Gray()
        {
            for (int x = 0; x < bitmap.Width; x++)
                for (int y = 0; y < bitmap.Height; y++)
                {
                    color[0, x, y] = bitmap.GetPixel(x, y).R;
                    color[1, x, y] = bitmap.GetPixel(x, y).R;
                    color[2, x, y] = bitmap.GetPixel(x, y).R;
                }
        }

        #endregion
       

        public Bitmap getBitmap()
        {
            for (int x = 0; x < bitmap.Width; x++)
                for (int y = 0; y < bitmap.Height; y++)
                {
                    bitmap.SetPixel(x, y, Color.FromArgb(color[0, x, y], color[1, x, y], color[2, x, y]));
                }
            return bitmap;
        }

    }
}