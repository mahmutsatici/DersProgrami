<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "ders_plani";

$silinecekHoca = $_POST["silinecekHoca"];


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT Hoca_Adi FROM hocalar WHERE Hoca_Adi = '" . $silinecekHoca . "'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  
  $sql2 = "DELETE FROM Hocalar WHERE Hoca_Adi = ('" . $silinecekHoca . "')";
  if ($conn->query($sql2) === TRUE) {
    echo $silinecekHoca . "adlı hoca silindi";
  } else {
    echo "Error: " . $sql2 . "<br>" . $conn->error;
  }
    
      
} else {
    echo "Böyle bir Hoca Yok";
  
}
$conn->close();
?>
