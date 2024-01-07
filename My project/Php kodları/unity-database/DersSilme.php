<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "ders_plani";

$silinecekDers = $_POST["silinecekDers"];


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT Ders_Adi FROM dersler WHERE Ders_Adi = '" . $silinecekDers . "'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  
  $sql2 = "DELETE FROM dersler WHERE Ders_Adi = ('" . $silinecekDers . "')";
  if ($conn->query($sql2) === TRUE) {
    echo $silinecekDers . "adlı ders silindi";
  } else {
    echo "Error: " . $sql2 . "<br>" . $conn->error;
  }
    
      
} else {
    echo "Böyle bir Ders Yok";
  
}
$conn->close();
?>
