<?php
//Задаём класс
class VK {
  
	public $token = ''; //Создаём публичную переменную для токена, который нужно отправлять каждый раз при использовании апи вк
  
	public function __construct($token) {
		$this->token = $token; //Забиваем в переменную токен при конструкте класса
	}
	 
	public function PhotoUploadServer($group_id) {
		//Заполняем массив $data инфой, которую мы через api отправим до вк getOwnerCoverPhotoUploadServer
		$data = array( 
			'group_id'      => $group_id,
			'v'            => '5.71', //Версия API VK.
			'crop_x'      => 0,
			'crop_y'      => 0,
			'crop_x2'      => 1590,
			'crop_y2'      => 400,
		);
		//Получаем ответ через функцию отправки до апи, которую создадим ниже
		$out = $this->request('https://api.vk.com/method/photos.getOwnerCoverPhotoUploadServer', $data);
		//И пусть функция вернёт ответ
		return $out['response'];
	}
	 
	public function UploadPhoto($url, $file) {
		$data = array( 
			'photo'      => new CURLFile($file), //Отправляем нашу обложку на сервера вк
		);
		//Получаем ответ через функцию отправки до апи, которую создадим ниже
		$out = $this->request($url, $data);
		//И пусть функция вернёт ответ
		
		return $out;
	}
	 
	public function SavePhoto($hash, $photo) {
		$data = array( 
			'hash'       => $hash,
			'photo'      => $photo,
			'v'            => '5.87', //Версия API VK
		);
		//Получаем ответ через функцию отправки до апи, которую создадим ниже
		$out = $this->request('https://api.vk.com/method/photos.saveOwnerCoverPhoto', $data);
		//И пусть функция вернёт ответ
		
		return $out;
	}
	  
	public function request($url, $data = array()) {
		$curl = curl_init(); // Curl in var 
		  
		$data['access_token'] = $this->token; // Token
		curl_setopt($curl, CURLOPT_URL, $url); 
		curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
		curl_setopt($curl, CURLOPT_CUSTOMREQUEST, 'POST');
		curl_setopt($curl, CURLOPT_POST, true);
		curl_setopt($curl, CURLOPT_POSTFIELDS, $data);
		//echo json_encode($data);
		  
		$out = json_decode(curl_exec($curl), true); // json
		  
		curl_close($curl); // Close curl
		  
		return $out;	}
}
