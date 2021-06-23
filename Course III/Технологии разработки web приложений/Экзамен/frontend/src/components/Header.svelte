<script>
    import {
        SkipToContent,
        Header,
        HeaderUtilities,
        HeaderGlobalAction,
    } from "carbon-components-svelte";
    import AppSwitcher20 from "carbon-icons-svelte/lib/AppSwitcher20";

</script>

<Header company="ПИ18-1" platformName="Гриднев Дмитрий Владимирович" href="/">
    <div slot="skip-to-content">
        <SkipToContent/>
    </div>
    <HeaderUtilities>
        <HeaderGlobalAction aria-label="App Switcher" icon="{AppSwitcher20}" on:click={()=> alert("Я кнопка, которая не любит работать")}/>
    </HeaderUtilities>
</Header>
