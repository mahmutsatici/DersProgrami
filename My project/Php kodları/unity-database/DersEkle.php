<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "ders_plani";

$DersAdi = $_POST["DersAdi"];


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT Ders_Adi FROM dersler WHERE Ders_Adi = '" . $DersAdi . "'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  echo "Bu isimde bir ders zaten var";

    
      
} else {

  $sql2 = "INSERT INTO dersler (Ders_Adi) VALUES ('" . $DersAdi . "')";
  if ($conn->query($sql2) === TRUE) {
    echo "Yeni ders oluşturuldu";
  } else {
    echo "Error: " . $sql2 . "<br>" . $conn->error;
  }
}
$conn->close();
?>
