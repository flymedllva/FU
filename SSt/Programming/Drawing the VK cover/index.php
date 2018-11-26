<?php
/**
 * @package VK Cover
 * @version 1.0
 */
/*
Plugin Name: VK Cover
Plugin URI: http://vk.com/flymedllva
*/
add_filter( 'cron_schedules', function ( $schedules ) {
 
	$schedules['every1minute'] = array(
		'interval' => 1 * MINUTE_IN_SECONDS/2/2,
		'display'  => __( '15 second' ),
	);
 
	return $schedules;
} );
 
add_action( 'init', function () {
	 
	// Если событие ещё не зарегистрировано в планировщике
	if ( !wp_next_scheduled( 'sheensay_new_event' ) ) {
		 
		wp_schedule_event( time(), 'every1minute', 'sheensay_new_event' );
	}
} );
 
add_action( 'sheensay_new_event', function () {
// Check server
//	$ch = curl_init(); 
//	curl_setopt($ch, CURLOPT_URL, "https://url/wp-content/plugins/vk/background.php.php");
//	curl_setopt($ch, CURLOPT_HEADER, 0);
//	curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
//
//	$output = curl_exec($ch);
//	curl_close($ch);
	include('background.php');
} );