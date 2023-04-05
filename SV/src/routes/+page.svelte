<h1>Notes</h1>

<script>
  /** @type {import('./$types').LayoutData} */
  export let data;
  console.log(data);
</script>

<div style="padding-left: 5px;">
    <button class="btn btn-primary">Add</button>
</div>
{#each data as note}
    <div style="padding: 5px;">
        <textarea class="form-control" placeholder="Note" bind:value="{note.content}"/>
        <button class="btn btn-danger">Delete</button>
    </div>
{/each}