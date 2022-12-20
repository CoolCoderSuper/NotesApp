<script>
	let count = 0
	let click_me = () => {
		count += 1
	}
	let or_me = () => {
		count -= 1
	}
</script>

<section>
	<div>The number is: {count}</div>
	<button class="btn btn-primary" on:click={click_me}>Click me</button>
	<button class="btn btn-secondary" on:click={or_me}>Or me</button>
</section>