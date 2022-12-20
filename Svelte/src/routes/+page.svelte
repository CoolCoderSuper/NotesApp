<script lang="ts">
	import { onMount } from "svelte";
	import { Message } from "../Message";
    let messages = new Array<Message>()
    let api = new Message("")
    let message = ""
    let loadMessages = async () => {
        messages = await api.getMessages()
    }
    let sendMessage = () => {
      messages.push(new Message(message))
      message = ""
    }
    onMount(() => loadMessages())
</script>
<section>
    <button class="btn btn-primary" on:click={loadMessages}>Refresh</button>
    {#each messages as m}
        <div>{m.content}</div>
    {/each}
    <input bind:value={message}/>
    <button class="btn btn-primary" on:click={sendMessage}>Send</button>
</section>