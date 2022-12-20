<script>
	import { ChuckNorris } from "./ChuckNorris";

    let api = new ChuckNorris()
    let joke = ""
    let category = "dev";

    let updateJoke = async () => {
        joke = await api.getJoke(category)
    }
</script>

<section>
	<div>{joke}</div>
    <button class="btn btn-primary" on:click={updateJoke}>Update</button>
    <input bind:value={category}/>
</section>