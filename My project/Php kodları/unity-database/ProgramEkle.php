<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "ders_plani";

$conn = new mysqli($servername, $username, $password, $dbname);

// Bağlantı hatası kontrolü
if ($conn->connect_error) {
    die("Bağlantı hatası: " . $conn->connect_error);
}

$Hoca = $_POST["Hocaa"];
$Ders = $_POST["Derss"];
$Sinif = $_POST["Siniff"];
$Gun = $_POST["Gunn"];
$Saat = $_POST["Saatt"];

// Hoca_ID'yi al
$sqlHoca = "SELECT Hoca_ID FROM hocalar WHERE Hoca_Adi = '$Hoca'";
$resultHoca = $conn->query($sqlHoca);

// Ders_ID'yi al
$sqlDers = "SELECT Ders_ID FROM dersler WHERE Ders_Adi = '$Ders'";
$resultDers = $conn->query($sqlDers);

// Sinif_ID'yi al
$sqlSinif = "SELECT Sinif_ID FROM siniflar WHERE Sinif_Adi = '$Sinif'";
$resultSinif = $conn->query($sqlSinif);

// Hoca, Ders ve Sinif id'lerini kontrol et
if ($resultHoca->num_rows > 0 && $resultDers->num_rows > 0 && $resultSinif->num_rows > 0) {
    $rowHoca = $resultHoca->fetch_assoc();
    $rowDers = $resultDers->fetch_assoc();
    $rowSinif = $resultSinif->fetch_assoc();

    $Hoca_ID = $rowHoca["Hoca_ID"];
    $Ders_ID = $rowDers["Ders_ID"];
    $Sinif_ID = $rowSinif["Sinif_ID"];

    // Kısıtlamaları kontrol et
    $sqlKisitlar = "SELECT * FROM kisitlar WHERE (Gun = '$Gun' AND Saat = '$Saat' AND Hoca_ID = '$Hoca_ID')";
    $resultKisitlar = $conn->query($sqlKisitlar);

    $sqlKisitlar2 = "SELECT * FROM kisitlar WHERE (Gun = '$Gun' AND Saat = '$Saat' AND Sinif_ID = '$Sinif_ID')";
    $resultKisitlar2 = $conn->query($sqlKisitlar2);

    $sqlKisitlar3 = "SELECT * FROM kisitlar WHERE (Ders_ID = '$Ders_ID')";
    $resultKisitlar3 = $conn->query($sqlKisitlar3);
    
    $sqlKisitlar4 = "SELECT * FROM kisitlar WHERE (Ders_ID = '$Ders_ID' AND Hoca_ID = '$Hoca_ID')";
    $resultKisitlar4 = $conn->query($sqlKisitlar4);



    // Kısıtlamalara uyan bir kayıt varsa hata mesajı göster
    if ($resultKisitlar->num_rows > 0) {
        echo $Hoca . ", " . $Gun . " günü " . $Saat . " saatinde dolu !";
    } else {

        if ($resultKisitlar2->num_rows > 0) {
            echo $Sinif . " sınıfı, " . $Gun . " günü " . $Saat . " saatinde dolu !";
        }
        else {

            if ($resultKisitlar3->num_rows > 0) {
                if ($resultKisitlar4->num_rows > 0) {
                    $sqlInsert = "INSERT INTO kisitlar (Hoca_ID, Ders_ID, Sinif_ID, Gun, Saat) VALUES ('$Hoca_ID', '$Ders_ID', '$Sinif_ID', '$Gun', '$Saat')";
                    if ($conn->query($sqlInsert) === TRUE) 
                    {
                        echo $Ders . " - " . $Sinif . " - " . $Hoca . " - " . $Gun . " " . $Saat . " programı oluşturuldu";
                    } 
                    else
                    {
                        echo "Error: " . $sqlInsert . "<br>" . $conn->error;
                    }
                }
                else 
                {
                    echo $Ders . " dersi başka hocaya atanmış.";
                }
            }
            else
            {
                $sqlInsert = "INSERT INTO kisitlar (Hoca_ID, Ders_ID, Sinif_ID, Gun, Saat) VALUES ('$Hoca_ID', '$Ders_ID', '$Sinif_ID', '$Gun', '$Saat')";
                if ($conn->query($sqlInsert) === TRUE) 
                {
                    echo $Ders . " - " . $Sinif . " - " . $Hoca . " - " . $Gun . " " . $Saat . " programı oluşturuldu";
                } 
                else
                {
                    echo "Error: " . $sqlInsert . "<br>" . $conn->error;
                }
            } 
        }
        
    }
} else {
    echo "Hoca, Ders veya Sinif bulunamadı.";
}

// Veritabanı bağlantısını kapat
$conn->close();
?>
