<?php
if(isset($_REQUEST['action'])){
    $action=$_REQUEST['action'];
}else{
    echo "invalid Data";
    exit;
}
if($action=="read"){
    readData();
}else if($action=="insertF"){
    insertFirst();
}else if($action=="updateR"){
    updateRecord();
}else if($action=="updateU"){
    updateUser();
}else if($action=="updateP"){
    updatePicture();
}
else if($action=="readT"){
    readTime();
}else if($action=="insertP"){
    uploadImage();
}
function connectToDatabase(){
    $connection=mysqli_connect("localhost","root","","game2048db");
    if (mysqli_connect_errno())
    {
        echo "Failed to connect to MySQL: " . mysqli_connect_error();
    }

    return $connection;
}
function readData(){
    $connection = connectToDatabase();
    $result=mysqli_query($connection,"select * from records");
    $output=array();
    while($row=mysqli_fetch_array($result))
    {
        $record=array();
        $record['UserName']= $row['name_user'];
        $record['UserPicture']= $row['picture'];
        $record['Score']= $row['score'];
        $record['Max']= $row['maxx'];
        $record['Move']= $row['move'];
        $record['Time']= $row['timee'];
        $record['serialId']= $row['serial_id'];
        $record['Flag']= $row['flag'];
        $output[]=$record;
    }
    echo json_encode($output);
    $result=mysqli_query($connection,"UPDATE records SET flag='0' ");
    mysqli_close($connection);
}
function readTime(){
    $today=date('Y-m-d');

    $yesterday = date('Y-m-d', strtotime(' -1 day'));

    $connection = connectToDatabase();
    $result=mysqli_query($connection,"select * from records where date_record='$yesterday' or date_record='$today'");
    $output=array();
    while($row=mysqli_fetch_array($result))
    {
        $record=array();
        $record['UserName']= $row['name_user'];
        $record['UserPicture']= $row['picture'];
        $record['Score']= $row['score'];
        $record['Max']= $row['maxx'];
        $record['Move']= $row['move'];
        $record['Time']= $row['timee'];
        $record['serialId']= $row['serial_id'];
        $record['Flag']= $row['flag'];
        $output[]=$record;
    }
    $result=mysqli_query($connection,"UPDATE records SET flag='0' ");
    echo json_encode($output);
    mysqli_close($connection);
}

function insertFirst(){
    $connection = connectToDatabase();
    $UserName=$_REQUEST['UserName'];
    $Score=$_REQUEST['Score'];
    $Max=$_REQUEST['Max'];
    $Move=$_REQUEST['Move'];
    $Time=$_REQUEST['Time'];
    $serialId=$_REQUEST['serialId'];
    $UserPicture=$_REQUEST['UserPicture'];
    $date=date('Y-m-d');
    $result=mysqli_query($connection,"insert into records values(0,'$UserName','$UserPicture','$Score','$Max','$Move','$Time','$serialId','$date','0')");
    mysqli_close($connection);
}
function updateRecord(){
    $connection = connectToDatabase();
    $Score=$_REQUEST['Score'];
    $Max=$_REQUEST['Max'];
    $Move=$_REQUEST['Move'];
    $Time=$_REQUEST['Time'];
    $serialId=$_REQUEST['serialId'];
    $date=date('Y-m-d');
    $result=mysqli_query($connection,"UPDATE records SET score='$Score',maxx='$Max',move='$Move',timee='$Time',date_record='$date' WHERE serial_id='$serialId'");
    mysqli_close($connection);
}
function updateUser(){
    $connection = connectToDatabase();
    $UserName=$_REQUEST['UserName'];
    $serialId=$_REQUEST['serialId'];
    $result=mysqli_query($connection,"UPDATE records SET name_user='$UserName' WHERE serial_id='$serialId'");
    mysqli_close($connection);
}
function updatePicture(){
    $connection = connectToDatabase();
    $UserPicture=$_REQUEST['UserPicture'];
    $serialId=$_REQUEST['serialId'];
    $result=mysqli_query($connection,"UPDATE records SET picture='$UserPicture',flag='1' WHERE serial_id='$serialId'");
    mysqli_close($connection);
}
function uploadImage(){
    $connection = connectToDatabase();
   /* $record="hj";
    $fileName                   =    basename($_FILES['uploadedfile']['name']);
    $ext                        =    "." . end(explode(".", $fileName));

    $target_path                =    "./image_user/";

    $new_name                   =   $record .$ext;
    $target_path                =    $target_path . $new_name;
    if (move_uploaded_file($_FILES['uploadedfile']['tmp_name'], $target_path)) {
        echo "The file " . basename($_FILES['uploadedfile']['name']);
    } else {
        echo "There was an error uploading the file, please try again!";
    }*/
    $ac=$_REQUEST['value'];
    echo $ac;
    $uploads_dir = './image_user'; //Directory to save the file that comes from client application.
    if ($_FILES["file"]["error"] == UPLOAD_ERR_OK) {
        $tmp_name = $_FILES["file"]["tmp_name"];
        $name ="jaber27"; //;
        $ext                        =    "." . end(explode(".",$_FILES["file"]["name"]));
        move_uploaded_file($tmp_name, "$uploads_dir/$ac");
    }
    /*print_r($_REQUEST);

    $uploadDir = '%SOMEPATH';
    $uploadFile = $uploadDir . $_FILES['userfile']['name'];
    print "<PRE>";
    if (move_uploaded_file($_FILES['userfile']['tmp_name'], $uploadFile))
    {
        print "File is valid, and was successfully uploaded. ";
    }
    else
    {
        print "Possible file upload attack!  Here's some debugging info:\n";
        print_r($_FILES);
    }
    print "</PRE>";*/

}
