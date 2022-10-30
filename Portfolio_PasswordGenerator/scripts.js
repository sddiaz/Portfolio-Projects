function copyToClipboard() {   
  // Grab our element
  var passwordText = document.getElementById("password");
  // Select the text in element
  passwordText.select();
  passwordText.setSelectionRange(0, 99999); 
   // Copy the text top clipboard
  navigator.clipboard.writeText(passwordText.value);
}