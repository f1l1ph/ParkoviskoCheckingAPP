using IronOcr;


namespace ParkoviskoCheckingAPP.services
{
    public class LicensePlateReaderService
    {
		public void ReadPlate(string pathToImage)
		{
			var Ocr = new IronTesseract();
			using (var Input = new OcrInput(pathToImage))
			{
				Ocr.Configuration.BlackListCharacters = "!@#$%^&'*()_+-{}[]:;/>.<,qwertyuiopasdfghjklzxcvbnm";
				Ocr.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.SingleWord;
				Ocr.Language = OcrLanguage.Slovak;
				Input.ReplaceColor(IronSoftware.Drawing.Color.DarkBlue, IronSoftware.Drawing.Color.White, 50);
				Input.ReplaceColor(IronSoftware.Drawing.Color.Blue, IronSoftware.Drawing.Color.White, 50);

				//Input.SaveAsImages("image_Saved2");

				Input.Deskew();
				Input.Contrast();
				Input.Scale(50);
				Input.Dilate();
				//Input.Despeckle();
				Input.Erode();
				Input.DeNoise();
				//Input.Sharpen();

				Input.SaveAsImages("image_Saved");
				Input.FindTextRegion();
				//detekuj hrany,
				var Result = Ocr.Read(Input);
				Console.WriteLine(Result.Text);
			}
		}
	
    }
}
