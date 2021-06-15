using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTools
{
    public class Tools
    {
        public static void TEXT()
        {
            String imgPath = "C:\\Users\\QDM\\Desktop\\123.png";
            using (Mat src = new Mat(imgPath, ImreadModes.Grayscale))
            {
                //1.Sobel算子，x方向求梯度
                Mat sobel = new Mat();
                Cv2.Sobel(src, sobel, MatType.CV_8U, 1, 0, 3);

                //2.二值化
                Mat binary = new Mat();
                Cv2.Threshold(sobel, binary, 0, 255, ThresholdTypes.Otsu | ThresholdTypes.Binary);

                //3. 膨胀和腐蚀操作的核函数
                Mat element1 = new Mat();
                Mat element2 = new Mat();
                OpenCvSharp.Size size1 = new OpenCvSharp.Size(30, 9);
                OpenCvSharp.Size size2 = new OpenCvSharp.Size(24, 6);

                element1 = Cv2.GetStructuringElement(MorphShapes.Rect, size1);
                element2 = Cv2.GetStructuringElement(MorphShapes.Rect, size2);

                //4. 膨胀一次，让轮廓突出
                Mat dilation = new Mat();
                Cv2.Dilate(binary, dilation, element2);

                //5. 腐蚀一次，去掉细节，如表格线等。注意这里去掉的是竖直的线
                Mat erosion = new Mat();
                Cv2.Erode(dilation, erosion, element1);

                //6. 再次膨胀，让轮廓明显一些
                Cv2.Dilate(erosion, dilation, element2, null, 3);
                //src.SaveImage("C:\\Users\\QDM\\Desktop\\321.png");
            }
        }
    }
}
