<script>
    import { writable } from "svelte/store";
    import { fade } from 'svelte/transition';
    import { elasticOut } from 'svelte/easing';

    let visible = true;

    function spin(node, { duration }) {
        return {
            duration,
            css: t => {
                const eased = elasticOut(t);

                return `
					transform: scale(${eased}) rotate(${eased * 1080}deg);
					color: hsl(
						${~~(t * 360)},
						${Math.min(100, 1000 - 1000 * t)}%,
						${Math.min(50, 500 - 500 * t)}%
					);`
            }
        };
    }

    // 1
    let questions = [
        { id: 1, text: `Test` },
        { id: 2, text: `Test2` },
        { id: 3, text: `Test3` }
    ];
    let answer = '';
    let selected;

    // 2
    let ih;
    let oh;
    let iw;
    let height = 50;

    // 3
    let img
    let img2
    $: if (img) {
        img2 = "https://sun9-26.userapi.com/impg/OtjR9J51YEpILoAXnCAEaM7FC2q6LYodkwdmVQ/f5F2xtsKd-0.jpg?size=400x0&quality=90&crop=176,40,297,297&sign=4f3b1ae51e94af13da903d83e7c3a27d&ava=1"
    } else {
        img2 = "https://sun1-24.userapi.com/impf/c831309/v831309520/137383/JaYdqxLg3J0.jpg?size=400x0&quality=90&crop=755,0,1714,1714&sign=aacd159224c05b1e22863c141ffca1ca&ava=1"
    }

    // 5
    let cats = [
        { id: 'J---aiyznGQ', name: 'Keyboard Cat' },
        { id: 'z_AbfPXTKms', name: 'Maru' },
        { id: 'OUtn3pvWmpg', name: 'Henri The Existential Cat' }
    ];

    let wrap = false;

    // 6
    let cats2 = [
        { id: 'J---aiyznGQ', name: 'Keyboard Cat' },
        { id: 'z_AbfPXTKms', name: 'Maru' },
        { id: 'OUtn3pvWmpg', name: 'Henri The Existential Cat' },
        { id: 'asas', name: 'Leks' }
    ];

    let cats_i = -1

    // 9
    let blurh = 2
</script>

<svelte:window bind:innerHeight={ih} bind:innerWidth={iw} bind:outerHeight={oh}/>

<div class="container">
    <div class="item">
        <div class="task-title">
            <h1>Task 3</h1>
            <h4>ПИ18-1, Вариант 5</h4>
            <h4>Гриднев Дмитрий Владимирович</h4>
        </div>
    </div>
    <div class="item">
        <h2>Часть 1</h2>
        <ul>
            <li>1: val()
                <label>
                    <select bind:value={selected} on:change="{() => answer = ''}">
                        {#each questions as question}
                            <option value={question}>
                                {question.text}
                            </option>
                        {/each}
                    </select>
                </label>
                <p>Выбранное: {selected ? selected.text : '[Ожидание...]'}</p>
            </li>
            <li>2: height({height}), innerHeight({ih}), outerHeight({oh})
                <br>
                <input type=number bind:value={height} min=0 max=100>
                <div class="hg" style="height: {height}px;">
                    test
                </div>
            </li>
            <li>3: :image
                <img src="{img2}" alt="" height="30px">
                <button on:click={() => img = !img}>Поменять</button>
            </li>
            <li>4: innerWidth()</li>
            {iw}
            <li>5: unwrap()</li>
                <button on:click={() => wrap = !wrap}>wrap/unwrap</button>
                <ul>
                    {#each cats as { id, name }, i}
                        {#if wrap}
                            <div class="unwrap">
                                <li><a target="_blank" href="https://www.youtube.com/watch?v={id}">{i + 1}: {name}</a></li>
                            </div>
                        {:else}
                            <li><a target="_blank" href="https://www.youtube.com/watch?v={id}">{i + 1}: {name}</a></li>
                        {/if}
                    {/each}
                </ul>
            <li>6: prevAll()</li>
                {#each cats2 as { id, name }, i}
                    {#if cats_i >= i}
                        <button on:click={() => cats_i = i} style="background-color: red;">{i + 1}: {name}</button>
                    {:else}
                        <button on:click={() => cats_i = i}>{i + 1}: {name}</button>
                    {/if}
                {/each}
            <li>7: event</li>
            <button on:click={() => alert(event.type)}>Test event</button>
            <li>8: hover()</li>
            <button class="gg">Hover test</button>
            <li>9: blur()</li>
            <img src="{img2}" alt="" height="70px" style="filter: blur({blurh}px);">
            <input type=number bind:value={blurh} min=0 max=100>
            <li>10: animate()</li>
            <label>
                <input type="checkbox" bind:checked={visible}>
                visible
            </label>
            {#if visible}
                <div class="centered" in:spin="{{duration: 4000}}" out:fade>
                    <span>АНИМАЦИЯ!</span>
                </div>
            {/if}
        </ul>
    </div>
</div>


<style>
    :global(body) {
        margin: 0;
    }

    .container {
        display: flex;
        flex-direction: column;
        background-color: #eee;
        height: 100vh;
        padding: 20px;
    }

    .task-title h1 {
        margin-top: 0;
        margin-bottom: 8px;
    }

    .task-title h4 {
        margin-top: 0;
        margin-bottom: 4px;
    }
    .hg {
        height: 50px;
        background-color: red;
    }
    .unwrap {
        background-color: red;
        margin: 4px;
    }
    .gg:hover {
        background-color: red;
    }

</style>
