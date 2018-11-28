<?php
//Задаём класс
class VK {
  
	public $token = '';  
	public function __construct($token) {
		$this->token = $token;
	}
	 
	public function PhotoUploadServer($group_id) {
		$data = array( 
			'group_id'      => $group_id,
			'v'            => '5.71',
			'crop_x'      => 0,
			'crop_y'      => 0,
			'crop_x2'      => 1590,
			'crop_y2'      => 400,
		);
		$out = $this->request('https://api.vk.com/method/photos.getOwnerCoverPhotoUploadServer', $data);
		return $out['response'];
	}
	 
	public function UploadPhoto($url, $file) {
		$data = array( 
			'photo'      => new CURLFile($file),
		);
		$out = $this->request($url, $data);		
		return $out;
	}
	 
	public function SavePhoto($hash, $photo) {
		$data = array( 
			'hash'       => $hash,
			'photo'      => $photo,
			'v'            => '5.87',
		);
		$out = $this->request('https://api.vk.com/method/photos.saveOwnerCoverPhoto', $data);		
		return $out;
	}
	  
	public function request($url, $data = array()) {
		$curl = curl_init(); 		  
		$data['access_token'] = $this->token; // Token
		curl_setopt($curl, CURLOPT_URL, $url); 
		curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
		curl_setopt($curl, CURLOPT_CUSTOMREQUEST, 'POST');
		curl_setopt($curl, CURLOPT_POST, true);
		curl_setopt($curl, CURLOPT_POSTFIELDS, $data);
		  
		$out = json_decode(curl_exec($curl), true); // json
		  
		curl_close($curl);
		  
		return $out;	}
}
