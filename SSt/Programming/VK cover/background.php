<?php
 
	$month = date('n'); // Number 1 month
	$months = array('января', 'февраля', 'марта', 'апреля','мая','июня','июля','августа','сентября','октября','ноября','декабря'); // Mounts 
	$current_date = 'Сегодня ' . date('d ' . $months[$month - 1] . ' Y') . ' года'; // Actual Date
	// Config
	$image = imageCreateFromJpeg('background_original.jpg'); // IMG
	$white = imagecolorallocate($image, 26, 51, 100); // COLOR
	
	$font = __DIR__ . '/Panton-ExtraBlack.otf';// FONT
	$center = 795; // Font center
	$ttf_box = imagettfbbox(20, 0, $font, $current_date); // Font size
	$position = $center - round(($ttf_box[2]-$ttf_box[0])/2); //Место, откуда нужно будет начать писать текст чтобы тот оказался посередине
 	
	// Time
	$rem = strtotime('2019-01-25 00:00:00') - time();
	$day = floor($rem / 86400) + 1;
	
	

	imagefttext($image, 44, 0, 754, 226, $white, $font, $day);
	imagejpeg($image, 'background.jpg', 100); // Save JPEG 100% 
	imagedestroy($image); // Clear
	
	// Day Text
	
	$image = imageCreateFromJpeg('background.jpg'); // IMG
	$white = imagecolorallocate($image, 255, 255, 255); // COLOR
	$font = __DIR__ . '/Panton-ExtraBlack.otf';// FONT
	$center = 795; // Font center

		
	$day_textarr = array( "В ритме\nтанца", "В космосе ничего\nне пропадает", "Из космоса\nграниц не видно!", "Выше\nтолько звёзды", "Полетели!", "Мы как ракета\nвышли в небеса", "Космос — это космос.\nНичего похожего на Земле нет.", "Мы покорили открытый\nкосмос, но не свой\nвнутренний мир.", "Космос зовет", "Из космоса\nграниц не видно", "Космос вовсе\nне так уж далек", "Космос в одно\nкасание", "Вселенная\nбесконечна?
", "Ближе к\nзвездам", "Вселенная невозможна.\nОна полна чудес и загадок.", "Ты\nпросто космос!", "Каждый человек - это\nмаленький космос" );
	$day_hight = 190;
	$i = rand(0,count($day_textarr)-1);	
	$day_text = $day_textarr[$i];
	
	if ($i == 6) {
		$font_size = 24;
	} elseif ($i == 4){
		$day_hight = 225;
		$font_size = 50;
	} elseif ($i == 7) { // Мы покорим...
		$day_hight = 160;
		$font_size = 30;
	} elseif ($i == 8) { // Космос зовет
		$day_hight = 225;
		$font_size = 50;
	}
	else {
		$font_size = 30;
	}
	
	imagefttext($image, $font_size, 0, 875, $day_hight, $white, $font, $day_text);
	imagejpeg($image, 'background.jpg', 100); // Save JPEG 100% 
	imagedestroy($image); // Clear

	

	// Date
	$image = imageCreateFromJpeg('background.jpg'); // IMG
	$white = imagecolorallocate($image, 255, 255, 255); // COLOR
	$font = __DIR__ . '/Panton-ExtraBlack.otf';// FONT
	$center = 795; // Font center
	$ttf_box = imagettfbbox(20, 0, $font, $current_date); // Font size
	$position = $center - round(($ttf_box[2]-$ttf_box[0])/2);

	$hour_time = date(H);
	if ($hour_time >= 6 and $hour_time < 12){
		$time = 'Утро';
	} elseif ($hour_time >= 12 and $hour_time < 18) {
		$time = 'День';
	} elseif ($hour_time >= 18 and $hour_time < 23) {
		$time = 'Вечер';
	} else {
		$time = 'Ночь';
	}
			
	imagefttext($image, 14, 0, 20, 380, $white, $font, $time);
	imagejpeg($image, 'background.jpg', 100); // Save JPEG 100% 
	header("Content-Type: image/jpeg");
	readfile("background.jpg");
	imagedestroy($image); // Clear
 
	include_once ('vk.class.php'); // Connect with vk.class.php
	 
	// API
	$vk = new vk('API');
	 
	$url = $vk->PhotoUploadServer(45425307); // Group ID
	$photo = $vk->UploadPhoto($url['upload_url'], 'background.jpg'); 
	$result = $vk->SavePhoto($photo['hash'], $photo['photo']); 
	echo "Фотография успешно обновлена";
?>