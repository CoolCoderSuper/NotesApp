<h1>Notes</h1>

<script>

    let notes = [
        {content: 'Note 1'},
        {content: 'Note 2'},
        {content: 'Note 3'},
    ];
</script>

<div style="padding-left: 5px;">
    <button class="btn btn-primary">Add</button>
</div>
{#each notes as note}
    <div style="padding: 5px;">
        <textarea class="form-control" placeholder="Note" bind:value="{note.content}"/>
        <button class="btn btn-danger">Delete</button>
    </div>
{/each}