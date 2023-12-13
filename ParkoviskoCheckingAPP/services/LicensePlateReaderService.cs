using IronOcr;

namespace ParkoviskoCheckingAPP.services;
//make this just an API call with Image
public class LicensePlateReaderService
{
	public static async Task<string> ReadPlate(byte[] img)
	{
		var Ocr = new IronTesseract();

        //var imageData = Convert.FromBase64String(base64Image);

        //var tempImagePath = "temp_image.png";
        //await File.WriteAllBytesAsync(tempImagePath, imageData);
        using var Input = new OcrInput(img);//tuto to vzdy padne
        Ocr.Configuration.BlackListCharacters = "!@#$%^&'*()_+-{}[]:;/>.<,qwertyuiopasdfghjklzxcvbnm";
        Ocr.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.SingleWord;
        //Ocr.Language = OcrLanguage.Slovak;
        Input.ReplaceColor(IronSoftware.Drawing.Color.DarkBlue, IronSoftware.Drawing.Color.White, 50);
        Input.ReplaceColor(IronSoftware.Drawing.Color.Blue, IronSoftware.Drawing.Color.White, 50);

        Input.Deskew();
        Input.Contrast();
        Input.Scale(50);
        Input.Dilate();
        //Input.Despeckle();
        Input.Erode();
        Input.DeNoise();
        //Input.Sharpen();

        //Input.SaveAsImages("image_Saved");
        Input.FindTextRegion();
        //ToDo detekuj hrany,
        var Result = await Ocr.ReadAsync(Input);

        //File.Delete(tempImagePath);
        return (Result.Text);
    }
}
