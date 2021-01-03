<script>
	export let name;
	import { onMount } from 'svelte';

	let table = undefined
	
	onMount(() => {
		table = window.$("#dt-table").DataTable(
				{
					'processing': true,
					'responsive': true,
				}
		);
		table.processing(true)
	});



	async function load() {
		const res = await fetch('https://apidata.mos.ru/v1/datasets/886/rows?&$orderby=Number&api_key=0235c3e482940f862217a646e7c479f5')
		const json = await res.json()
		if (table === undefined) {
			table = window.$("#dt-table").DataTable();
		}
		json.forEach(item => {
			table.row.add( [
				item.global_id,
				item.Cells.ObjectName,
				item.Cells.Address,
				item.Cells.WebSite
			] ).draw( false );
		})
		table.processing( false )
	}

	load()

</script>

<main>
	<div class="container">
		<table id="dt-table">
			<thead>
			<tr>
				<th>ID</th>
				<th>Имя объекта</th>
				<th>Адрес</th>
				<th>Сайт</th>
			</tr>
			</thead>
			<tbody>
		</table>
	</div>
</main>

<style>
	body {
		background-color: #eee;

	}
	main {
		padding: 100px;
	}
	.container {
		/*margin: 2%;*/
		background-color: white;
		padding: 20px;
		border-radius: 25px;
		box-shadow: 0 0 4px rgba(0, 0, 0, 0.25);
	}

</style>