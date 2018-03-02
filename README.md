# RequestTimeOutReproMultiPart
The is a test solution to reproduce the Kestrel "BadHttpRequestException - Request timed out" Exception using a multi-part request

To reproduce the issue:
  * Run the web application
  * Add the path of 2 or more large files (I was using a 50MB file and a 800MB file) to the console app config file
  * Run the console app, it will try to upload the specified file to the web app
  * Check the log file for the exception
  * Alternatively, use curl: curl -F 'file1=@PathToLargeFile1' -F 'file2=@PathToLargeFile2' http\://localhost:5000/api/values/upload