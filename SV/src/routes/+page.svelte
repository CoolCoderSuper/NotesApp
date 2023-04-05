<h1>Notes</h1>

<script>
  /** @type {import('./$types').LayoutData} */
  export let data;

    async function load()
    {
        const res = await fetch(`https://coolcodersuper-crispy-potato-9g5q6w4pj52xx4j-5124.preview.app.github.dev/Notes`);
        data.notes = await res.json();
    }
</script>

<div style="padding-left: 5px;">
    <button class="btn btn-primary" on:click={async () =>
        {
            let note = {
                    id: 0,
                    content: ''
                }
            const res = await fetch(`https://coolcodersuper-crispy-potato-9g5q6w4pj52xx4j-5124.preview.app.github.dev/Notes`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(note)
            });
            await load();
        }}>Add</button>
</div>
{#each data.notes as note}
    <div style="padding: 5px;">
        <textarea class="form-control" placeholder="Note" bind:value={note.content} on:input={async () => {
            note.content = event.target.value;
            const res = await fetch(`https://coolcodersuper-crispy-potato-9g5q6w4pj52xx4j-5124.preview.app.github.dev/Notes/`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(note)
            });
            await load();
        }}/>
        <button class="btn btn-danger" on:click={async () => {
            const res = await fetch(`https://coolcodersuper-crispy-potato-9g5q6w4pj52xx4j-5124.preview.app.github.dev/Notes/${note.id}`, {
                method: 'DELETE'
            });
            await load();
        }}>Delete</button>
    </div>
{/each}