# Cognitive.Service.Image.OCR

Optical Character Recognition (OCR) detects text in an image. Extracts characters into a usable character.      
First, subscribe on Microsoft Azure. 
Microsoft gives a 7-day trial Subscription Key : https://azure.microsoft.com/en-us/try/cognitive-services/ . We can use that Subscription key for testing purposes. 
you need to log into the Azure Portal with our Azure credentials. Then we need to create an Azure Computer Vision Subscription Key in the Azure portal.
var caracters= OCR.GetImageOCR(key,imagePath, endPoint = "https://westus.api.cognitive.microsoft.com/vision/v1.0/ocr")

Requirements 
      These are the major requirements mentioned in the Microsoft docs.
      1-Supported input methods: Raw image binary in the form of an application/octet stream or image URL.
      2-Supported image formats: JPEG, PNG, GIF, BMP.
      3-Image file size: Less than 4 MB.
      4-Image dimension: Greater than 50 x 50 pixels.
anouar.ben.zahra@gmail.com
