<script lang="ts">
	import { fade, fly } from 'svelte/transition';
	import { flip } from 'svelte/animate';
	import { Collapse, Button, Card, Jumbotron, Fade } from 'sveltestrap';
	import { FormGroup, Input, Label,
    CardBody,
    CardFooter,
    CardHeader, ButtonGroup,
    CardSubtitle,
    CardText,
    CardTitle } from 'sveltestrap';
	import {urlCreateNewNote, urlGetAllNotes, urlNote, urlEditNote} from './constants';

	
	// Top
	let isClosed: boolean = false;
	let newNoteText: string = '';


	// Edit
	let editId = undefined;
	let editText = undefined;

	// Body

	class Note {
		id: number
		text: string
		date: string
	}


	let list: Array<Note> = [];
	let did_remove: boolean = false;


	async function createNote() {
		const res = await fetch(urlCreateNewNote, {
			method: 'POST',
			body: JSON.stringify({text: newNoteText})
		})
		const json = await res.json()
		openCreateMenu()
		if (json.detail) {
			alert("Не удалось создать заметку. " + json.detail)
		} else if (json) {
			list = [json, ...list]
		}
	}

	async function deleteNote(i: number, note: Note) {
		const res = await fetch(urlNote + "/" + note.id, {
			method: 'DELETE',
			body: JSON.stringify({id: note.id})
		})
		const json = await res.json()
		if (json.detail) {
			alert("Не удалось удалить заметку. " + json.detail)
		} else if (json && json === true) {
			list = [...list.slice(0, i), ...list.slice(i + 1)];
			did_remove = true;
		}
	}

	async function editNote(i: number, note: Note) {
		if (editId === undefined && editText === undefined) {
			editId = note.id
			editText = note.text
		} else {
			const res = await fetch(urlEditNote, {
				method: 'PUT',
				body: JSON.stringify({id: note.id, text: editText})
			})
			editId = undefined
			editText = undefined
			const json = await res.json()
			if (json.detail) {
				alert("Не удалось отредактировать заметку. " + json.detail)
			} else if (json) {
				list[i] = json
			}
		}
	}

	async function loadAllNotes() {
		const res = await fetch(urlGetAllNotes)
		const json = await res.json()
		if (json.detail) {
			console.log(json.detail)
		} else if (json.notes) {
			list = json.notes
		}
	}

	var options = {
		hour:'numeric',
		minute:'numeric',
		second:'numeric',
		year: 'numeric',
		month: 'numeric',
		day: 'numeric',
		timezone: 'UTC'
	};
	function formatDate(date: string) {
		let d = new Date(date)
		return d.toLocaleString("ru", options)
	}

	function openCreateMenu() {
		if (isClosed) {
			newNoteText = ''
		}
		isClosed = !isClosed
	}

	loadAllNotes()

</script>

<svelte:head>
  <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
</svelte:head>
	
<main>
	<Jumbotron>
		<h1 class="display-5">СберЗаметки</h1>
		<p class="lead">
			Task 6, Гриднев Д.В. ПИ18-1
		</p>
		
		<Button color="primary" on:click={openCreateMenu} class="mb-3 new-note">
			{#if !isClosed}
				Новая заметка
			{:else}
				Отмена
			{/if}
		</Button>
		
		<Collapse isOpen={isClosed}>
			<Card body>
				<FormGroup>
					<h4>Новая заметка</h4>
					<hr class="my-2 mb-4" />
					<Label>Текст заметки</Label>
					<Input type="text" bind:value={newNoteText} class="mb-3"/>
					<Button color="primary" on:click={createNote} class="mb-3">
						Создать
					</Button>
				</FormGroup>
			</Card>
		</Collapse>
	</Jumbotron>

	{#each list as object, i (object.id)}
		<div animate:flip in:fade out:fly={{x:500}}>
			<Card class="mb-3">
				<CardHeader>
					<CardTitle class="mb-0">#{object.id} · <Label class="mb-0">{formatDate(object.date)}</Label></CardTitle>
				</CardHeader>
				<CardBody>
					<CardText>
						
						{#if editId === object.id}
							<Input type="text" bind:value={editText} class="mb-3"/>
						{:else}
							{object.text}
						{/if}
					</CardText>
					<ButtonGroup>
						<Button
							on:click="{() => editNote(i, object)}"
							disabled="{editId !== undefined && editId !== object.id ? true : false}"
							outline
							color="primary"
							size="sm">
							{#if editId !== object.id}
								Изменить
							{:else}
								Сохранить
							{/if}
						</Button>
						<Button
							on:click="{() => deleteNote(i, object)}"
							disabled="{editId !== undefined ? true : false}"
							outline
							color="danger"
							size="sm">
							Удалить
						</Button>
					  </ButtonGroup>
				</CardBody>
			</Card>
		</div>
	{/each}

	{#if list.length === 0 && did_remove}
	<div in:fade={{delay:600}}>
		<p>Нет записей</p>
	</div>
{/if}
</main>

<style>
	main {
		padding: 1em;
		margin: 0 auto;
	}
	:global(.new-note) {
		min-width: 180px;
	}
</style>