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
    <button on:click={updateJoke}>Update</button>
</section>