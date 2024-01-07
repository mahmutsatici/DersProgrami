<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unity_database";

$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT username FROM users WHERE username = '" . $loginUser . "'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  echo "Kullanıcı Adı Zaten Var";

    
      
} else {

  $sql2 = "INSERT INTO users (username, password, level) VALUES ('" . $loginUser . "', '" . $loginPass . "', 1)";
  if ($conn->query($sql2) === TRUE) {
    echo "Yeni Kullanıcı oluşturuldu";
  } else {
    echo "Error: " . $sql2 . "<br>" . $conn->error;
  }
}
$conn->close();
?>
