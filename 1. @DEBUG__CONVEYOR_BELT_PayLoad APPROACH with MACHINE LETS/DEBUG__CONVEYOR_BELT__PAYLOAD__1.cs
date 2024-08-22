using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG__CONVEYOR_BELT__PAYLOAD__1 : MonoBehaviour
{

	[Range(-1, 10)]
	public int state = 0;


	
	private void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			StopAllCoroutines();
			StartCoroutine(STIMULATE());
		}

	}
	


	public bool DRAW_DEBULG_LINES = true;


	public Camera cam;

	public GameObject PREFAB__conveyor_belt__straight,
					  PREFAB__conveyor_belt__curved_r,
					  PREFAB__conveyor_belt__curved_l,
					  PREFAB__payload__arrow,

					  PREFAB__machine__producer,
					  PREFAB__machine__combiner,
					  PREFAB__machine__splitter,

					  PREFAB__machine__consumer,
					  PREFAB__pointer_cube;

	public Material conveyor_belt__mat;




	IEnumerator STIMULATE()
	{
		#region fame_rate
		QualitySettings.vSyncCount = 1;
		yield return null;
		yield return null;
		#endregion



		DRAW.dt = Time.deltaTime;

		// INITIALIZE_GRID with EMPTY tiles //
		STORE.dimension = new int[2] { 10, 10 };
		STORE.INITIALIZE();
		// INITIALIZE_GRID with EMPTY tiles //


		

		// _RENDER_ PREFABS , ONOTOALIZE //
		_RENDER_.OFFSET_EVERYTHING = new Vector3(0f, 0f, 0f);

		_RENDER_.PREFAB__conveyor_belt__straight = this.PREFAB__conveyor_belt__straight;
		_RENDER_.PREFAB__conveyor_belt__curved_r = this.PREFAB__conveyor_belt__curved_r;
		_RENDER_.PREFAB__conveyor_belt__curved_l = this.PREFAB__conveyor_belt__curved_l;
		_RENDER_.PREFAB__payload__arrow = this.PREFAB__payload__arrow;

		_RENDER_.PREFAB__machine__combiner	= this.PREFAB__machine__combiner;
		_RENDER_.PREFAB__machine__splitter	= this.PREFAB__machine__splitter;
		
		_RENDER_.PREFAB__machine__producer = this.PREFAB__machine__producer;
		_RENDER_.PREFAB__machine__consumer = this.PREFAB__machine__consumer;

		_RENDER_.PREFAB__pointer_cube = this.PREFAB__pointer_cube;




		_RENDER_._mat_belt__conveyor_belt = this.conveyor_belt__mat;

		_RENDER_.INITIALIZE();
		// _RENDER_ PREFABS , ONOTOALIZE //




		_INPUT_.cam = this.cam;
		StartCoroutine(_INPUT_.COROUTINE_EVENT(STORE.dimension));


		// TODO : exit flow block visual , pointer bube visual , producer , converter //


		//STORE.UPDATE__CONVEYOR_BELT__CONFIGURATIONS__and__PATHS_CALCULATION();
		ORDER__OF__CALCULATION.PERFORM();

		StartCoroutine(COROUTINE__MOVE_RESOURCES__WITHOUT_AFFECTING_INPUT());






		// NETWORK //
		yield return NEWTWORK._send_request();
		// NETWORK //




		while (true)
		{
			/*
				DRAW.QUAD(V2(0, 0));
				DRAW.DIR(V2(0, 0), this.state);
			*/



			
			// if same key or mouse event is used at 2 different situation lead to unfavourable case
			if (Input.GetKeyDown(KeyCode.L))
			{
				LOG.FILE
				(
						LOG.conveyor_belt__1D(STORE.CONVEYOR_BELT__1D) +
						"\n\n\n\n\n\n\n\n" +
						LOG.machine__1D(STORE.MACHINE__1D) +
						"\n\n\n\n\n\n\n\n" +
						LOG.PATHS(STORE.PATHS) + 
						"\n\n\n\n\n\n\n\n" +
						LOG.PAYLOADS(STORE.PAYLOADS) + 
						"\n\n\n\n\n\n\n\n" +
						LOG.GRID(STORE.GRID)
				);
			}
			

			if (DRAW_DEBULG_LINES)
			{
				//
				_RENDER_.RENDER__DRAW_TILES(STORE.GRID, STORE.PAYLOADS);
			}

			// INPUT EVENTS //
			// _INPUT_.EVENT(STORE.dimension);
			// INPUT EVENTS //


			yield return null;
		}

	}




	IEnumerator COROUTINE__MOVE_RESOURCES__WITHOUT_AFFECTING_INPUT()
	{


		#region METHOD - 0
		//
		StartCoroutine(COROUTINE__ADD_payloads__to_path_at_steady_rate__without_affecting__movement__or__INPUT());


		while (true)
		{
			// PATH.FUNCTIONALITY__MOVE_RESOURCES();

			// PATH.FUNCTIONALITY_MOVE_RESOURCES__PayLoad_METHOD_();
			ORDER__OF__MOVEMENT_OF_PAYLOAD.PERFORM();




			_RENDER_.UPDATE__mat__conveyor_belt(-0.02f);
			PayLoad.move_increment = 0.02f * 1.2f;

			PayLoad.proximity = 0.5f;


			for (int i0 = 0; i0 < 3; i0 += 1)
			{
				//
				if (this.DRAW_DEBULG_LINES)
				{
					//
					_RENDER_.RENDER__DRAW_TILES(STORE.GRID, STORE.PAYLOADS);
				}

				//
				yield return null;
			}


			for(int i0 = 0;i0 < STORE.PAYLOADS.Count; i0 += 1)
			{
				_RENDER_.UPDATE__payload__TRANSFORM(STORE.PAYLOADS[i0]);
			}



			yield return null;
		}


		#endregion


		#region METHOD - 1 // animate  --didnt go well
		/*
		while (true)
		{
			yield return PATH.FUNCTIONALITY__MOVE_RESOURCES__with__t();

			yield return null;
		}
		*/
		#endregion

	}

	IEnumerator COROUTINE__ADD_payloads__to_path_at_steady_rate__without_affecting__movement__or__INPUT()
	{
		while (true)
		{
			for (int i0 = 0; i0 < 8; i0 += 1)
			{
				yield return null;
			}


			//
			if (STORE.PATHS.Count != 0) //STORE.PATHS.Count != 0)
			{
				/*
				//
				if (STORE.PATHS[0].path_type == C.circular_path) { yield return null; continue; }


				//
				int resource_type = C.OIL__resource;
				


				bool resource_added_0 = STORE.PATHS[0].Add_PayLoad_from__machine(resource_type : resource_type);
				if (resource_added_0)
				{
					_RENDER_.CREATE__payload(resource_type: resource_type);
					//
					Debug.Log("Resource Added ....");
				}
				*/

			}


			// 

			yield return null;
		}
	}






	///// STUFF /////

	//
	/*
		EXPAND IN A WAY, WHERE A NEW TYPE OF TILE 
		COULD BE INCLUDED AMONG A TILE - TYPE
	*/


	/*
	

		//// WHEN CREATION OR MODIFICATION OR REMOVAL OF ANY TILE IS MADE ////

		// update tile index(if removed loop through all belts , machines to update tile_index) on grid and type type
		GRID TILES
		UPDATE_TILE_INDEX__under_Each__TILE_TYPE__if_a__TILE_TYPE__is__removed

		// by now all tiles has state of tile


		// linkage_type and enter flow type, enter flow index, enter flow let index
		CALCULATE__CONVEYOR_BELT__LINKAGE_TYPE__ENTER_FLOW__for_each__tile		done
		CALCULATE__MACHINE__ENTER_FLOW__for__each_tile							done


		CALCULATE__BEZIER__CURVE__for_each__conveyor_belt				done


		//exit flow type, exit flow index, exit flow let index
		CALCULATE__CONVEYOR_BELT__EXIT_FLOW__for__each_tile				done
		CALCULATE__MACHINE__EXIT_FLOW__for__each_tile					done


		// eraze all the paths and recrete each paths for each discontinue in CONVEYOR_BELT__1D (using its enter , exit flow)
		CALULATE_PATH__for_each__conveyor_belt__discontinuity__of__flow



		// PayLoad - attached to conveyor_belt and stored in PAYLOADS
		INCLUDE_PAYLOADS__in__path__they__associated_in_order_of_distance_from_start_of_path


		//// WHEN CREATION OR MODIFICATION OR REMOVAL OF ANY TILE IS MADE ////








		//// at every Interval ///

		for each machine
			for each outlet
				ADD_PAYLOAD_to__belt_associated_PATH__from_machine()
		
		for each path
			MOVE_PAYLOAD_along_the_path()

		//// at every Interval ///




	*/


	public static class ORDER__OF__CALCULATION
	{

		public static void PERFORM(int removed__tile_type = -1)
		{

			// 0 -
			// update tile index(if removed loop through all belts , machines to update tile_index) on grid and type type
			// GRID TILES
			// UPDATE_TILE_INDEX__under_Each__TILE_TYPE__if_a__TILE_TYPE__is__removed

			if (removed__tile_type != C.none)
			{

				if (removed__tile_type == C.CONVEYOR_BELT__tile)
				{

					// Re-index TILE_index_in_holder //
					for (int i0 = 0; i0 < STORE.CONVEYOR_BELT__1D.Count; i0 += 1)
					{
						int[] global_pos = STORE.CONVEYOR_BELT__1D[i0].global_pos;
						STORE.GRID[global_pos[1]][global_pos[0]].TILE_INDEX_in_HOLDER = i0;
					}
					// Re-index TILE_index_in_holder //
				}

				else if (removed__tile_type == C.MACHINE__tile)
				{
					// Re-index TILE_index_in_holder //
					for (int i0 = 0; i0 < STORE.MACHINE__1D.Count; i0 += 1)
					{

						int[] global_pos = STORE.MACHINE__1D[i0].global_pos;
						//
						for (int i1 = 0; i1 < STORE.MACHINE__1D[i0].LET_1D.Count; i1 += 1)
						{
							LET let = STORE.MACHINE__1D[i0].LET_1D[i1];
							int[] global_pos_let = new int[]
							{
								global_pos[0] + let.local_pos[0],
								global_pos[1] + let.local_pos[1],
							};

							STORE.GRID[global_pos_let[1]][global_pos_let[0]].TILE_INDEX_in_HOLDER = i0;
						}

					}
					// Re-index TILE_index_in_holder //
				}


			}




			// 1 -
			// linkage_type and enter flow type, enter flow index, enter flow let index
			// CALCULATE__CONVEYOR_BELT__LINKAGE_TYPE__ENTER_FLOW__for_each__tile

			for (int i0 = 0; i0 < STORE.CONVEYOR_BELT__1D.Count; i0 += 1)
			{
				CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[i0];
				belt.CALCULATE__linkage_type__enter_flow();
			}


			// 2 -
			// CALCULATE__BEZIER__CURVE__for_each__conveyor_belt
			for (int i0 = 0; i0 < STORE.CONVEYOR_BELT__1D.Count; i0 += 1)
			{
				CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[i0];
				// bezier_curve //
				belt.CALCULATE__BEZIER_CURVE();
				// bezier_curve //
			}






			// 3 -
			// exit flow type, exit flow index, exit flow let index
			// CALCULATE__CONVEYOR_BELT__EXIT_FLOW__for__each_tile
			for (int i0 = 0; i0 < STORE.CONVEYOR_BELT__1D.Count; i0 += 1)
			{
				CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[i0];
				belt.CALCULATE__exit_flow();
			}


			// 3 -
			// exit flow type, exit flow index, exit flow let index
			// CALCULATE__MACHINE_BELT__EXIT_FLOW__for__each_tile
			for(int i0 = 0; i0 < STORE.MACHINE__1D.Count; i0 += 1)
			{
				MACHINE machine = STORE.MACHINE__1D[i0];
				machine.CALCULATE__MACHINE__EXIT_FLOW__for__each_tile();
			}




			// 4 -
			// eraze all the paths and recrete each paths for each discontinue in CONVEYOR_BELT__1D (using its enter , exit flow)
			// CALULATE_PATH__for_each__conveyor_belt__discontinuity__of__flow
			CALCULATE_PATH__for_each__conveyor_belt__discontinuity__of__flow();




			// 5 -
			// PayLoad - attached to conveyor_belt and stored in PAYLOADS
			// INCLUDE_PAYLOADS__in__path__they__associated_in_order_of_distance_from_start_of_path
			INCLUDE_PAYLOADS__in__path__they__associated_in_order_of__distance_from_start_of_path();

		}


		//
		public static void CALCULATE_PATH__for_each__conveyor_belt__discontinuity__of__flow()
		{
			STORE.PATHS = new List<PATH>();

			bool[] explored = new bool[STORE.CONVEYOR_BELT__1D.Count];

			#region INITIALIZE_explored
			for (int i0 = 0; i0 < STORE.CONVEYOR_BELT__1D.Count; i0 += 1)
			{
				//
				explored[i0] = false;
			}
			#endregion


			int iter_0 = 0;
			while (true)
			{
				iter_0 += 1;
				if (iter_0 > 1000) { Debug.Log("iter_0 .... stuck"); break; }

				#region Weather all_belts_explored ?
				bool all_belts_explored = true;

				for (int i0 = 0; i0 < explored.Length; i0 += 1)
				{
					//
					if (explored[i0] == false) { all_belts_explored = false; break; }
					//
				}

				if (all_belts_explored) { break; }
				#endregion


				CONVEYOR_BELT start_belt = null;


				int start_belt__index__to_calculate_circular_path = C.none;
				int path_type = C.linear_path;

				#region find a random not explored CONVEYOR_BELT__tile
				for (int i0 = 0; i0 < STORE.CONVEYOR_BELT__1D.Count; i0 += 1)
				{
					//
					if (!explored[i0])
					{
						start_belt = STORE.CONVEYOR_BELT__1D[i0];
						// explored //
						explored[i0] = true;
						// explored //

						start_belt__index__to_calculate_circular_path = i0;

						break;
					}
					//

				}
				#endregion


				#region find the start_belt of path // until enter is not CONVEYOR_BELT__tile
				int iter_1 = 0;
				while (true)
				{
					iter_1 += 1;
					if (iter_1 > 1000) { Debug.Log("iter_1 .... stuck"); break; }
					if (start_belt.enter_flow_type != C.CONVEYOR_BELT__flow)
						break;



					if (start_belt.enter_flow_TILE_index == start_belt__index__to_calculate_circular_path)
					{
						//
						start_belt = STORE.CONVEYOR_BELT__1D[start_belt.enter_flow_TILE_index];
						path_type = C.circular_path;
						break;
					}

					//
					start_belt = STORE.CONVEYOR_BELT__1D[start_belt.enter_flow_TILE_index];
				}

				#endregion



				PATH path = new PATH()
				{
					belts = new List<CONVEYOR_BELT>() { start_belt },
					payloads = new List<PayLoad>(),
					path_type = path_type
				};
				//


				#region path from start_belt to end_belt

				CONVEYOR_BELT end_belt = start_belt;
				// 
				int iter_2 = 0;

				while (true)
				{
					iter_2 += 1;
					if (iter_2 > 1000) { Debug.Log("iter_2 .... stuck"); break; }


					if (path.path_type == C.circular_path)
					{
						if (end_belt.exit_flow_TILE_index == start_belt__index__to_calculate_circular_path)
						{
							break;
						}
						//

						// explored //
						// explored[end_belt.exit_flow_TILE_index] = true;
						// explored //

						end_belt = STORE.CONVEYOR_BELT__1D[end_belt.exit_flow_TILE_index];
						path.belts.Add(end_belt);
					}
					//

					else if (path.path_type == C.linear_path)
					{
						if (end_belt.exit_flow_type != C.CONVEYOR_BELT__flow)
						{
							break;
						}

						// explored //
						// explored[end_belt.exit_flow_TILE_index] = true;
						// explored //

						end_belt = STORE.CONVEYOR_BELT__1D[end_belt.exit_flow_TILE_index];
						path.belts.Add(end_belt);

					}
				}
				#endregion
				//
				STORE.PATHS.Add(path);



				for (int i1 = 0; i1 < path.belts.Count; i1 += 1)
				{
					CONVEYOR_BELT belt = path.belts[i1];
					explored[STORE.CONVEYOR_BELT__1D.IndexOf(belt)] = true;

					belt.PATH_index = STORE.PATHS.Count - 1;
					belt.belt_index_in__path = i1;
				}



				string str = "";
				for (int i0 = 0; i0 < explored.Length; i0 += 1)
				{
					str += explored[i0] + " - ";
				}
				// Debug.Log(str);

			}







		}
		//
		public static void INCLUDE_PAYLOADS__in__path__they__associated_in_order_of__distance_from_start_of_path()
		{

			for (int i0 = 0; i0 < STORE.PAYLOADS.Count; i0 += 1)
			{
				PayLoad payload = STORE.PAYLOADS[i0];
				PATH path = STORE.PATHS[payload.belt.PATH_index];


				float dt = payload.t - (int)(payload.t);
				float new_t = payload.belt.belt_index_in__path + dt;
				payload.t = new_t;

			}

			//
			for (int i0 = 0; i0 < STORE.PATHS.Count; i0 += 1)
			{
				STORE.PATHS[i0].payloads = new List<PayLoad>();
			}

			//
			for (int i0 = 0; i0 < STORE.PAYLOADS.Count; i0 += 1)
			{
				PayLoad payload = STORE.PAYLOADS[i0];
				PATH path = STORE.PATHS[STORE.PAYLOADS[i0].belt.PATH_index];


				if (path.payloads.Count == 0)
				{
					path.payloads.Add(payload);
				}
				else
				{
					int i1 = 0;
					for (; i1 < path.payloads.Count; i1 += 1)
					{
						if (payload.t > path.payloads[i1].t)
						{
							break;
						}
					}



					if (i1 == path.payloads.Count) { path.payloads.Add(payload); }
					else { path.payloads.Insert(i1, payload); }





				}





			}

		}




		public static void PERFORM_RENDER()
		{
			// _RENDER_ //

			// UPDATE ALL the conveyor belt --type of belt //
			for (int i0 = 0; i0 < STORE.CONVEYOR_BELT__1D.Count; i0 += 1)
			{
				_RENDER_.UPDATE__conveyor_belt__TRANSFORM(STORE.CONVEYOR_BELT__1D[i0]);
			}

			// UPDATE ALL the payload --pos , --rotation //
			for (int i0 = 0; i0 < STORE.PAYLOADS.Count; i0 += 1)
			{
				_RENDER_.UPDATE__payload__TRANSFORM(STORE.PAYLOADS[i0]);
			}
			// _RENDER_ //


			// UPDATE ALL the conveyor belt --type of belt //
			for (int i0 = 0; i0 < STORE.MACHINE__1D.Count; i0 += 1)
			{
				_RENDER_.UPDATE__machine__TRANSFORM(STORE.MACHINE__1D[i0]);
			}


		}

	}




	#region ORDER__OF__MOVEMENT_OF_PAYLOAD

	// DO NOT ADD -1 PayLoad with some resource_type -> appear as if resource travelling but it doesnt
	public static class ORDER__OF__MOVEMENT_OF_PAYLOAD
	{
		// 0. TAKE__PAYLOAD__from__MACHINE_INLET__and_add_to_its__resource_count (if possible) 
		//		and then move to outlet path (if possible)

		// MOVE resource along path see if head payload of a path could add to machine inlet payload(if possible)


		public static void PERFORM()
		{
			// for each machine
			//		for each outlet
			//			ADD_PAYLOAD_to__belt_associated_PATH__from_machine()
			for (int i0 = 0; i0 < STORE.MACHINE__1D.Count; i0 += 1)
			{
				//
				MACHINE machine = STORE.MACHINE__1D[i0];

				//
				machine.TAKE__PAYLOAD_FROM_INLET___and___ADD__PAYLOAD__TO_PATH();
			}






			// start coroutine
			// stop coroutine before removing machine
			// not coroutine for now


			// for each path
			//		MOVE_PAYLOAD_along_the_path()
			for (int i0 = 0; i0 < STORE.PATHS.Count; i0 += 1)
			{
				PATH path = STORE.PATHS[i0];
				if (path.path_type == C.circular_path) { circular_move__payload(path); continue; }



				path.path_limit = path.belts.Count; // >= limit //


				//
				for (int i1 = 0; i1 < path.payloads.Count; i1 += 1)
				{
					PayLoad payload = path.payloads[i1];


					if (i1 != 0)
					{
						//
						float next_distance_t_of_payload = payload.t + PayLoad.move_increment;

						float future__distance_between_payloads = path.payloads[i1 - 1].t - next_distance_t_of_payload;
						if (future__distance_between_payloads >= PayLoad.proximity)
						{
							//
							payload.t = next_distance_t_of_payload;

							int i_I = (int)payload.t;
							payload.belt = path.belts[i_I];
						}
						//
					}


					// the payloads head
					else if (i1 == 0)
					{
						float next_distance_t_of_payload = payload.t + PayLoad.move_increment;

						float future__distance_between_payload_and_terminal = path.path_limit - next_distance_t_of_payload;

						if (future__distance_between_payload_and_terminal > 0f)
						{
							//
							payload.t = next_distance_t_of_payload;

							int i_I = (int)payload.t;
							payload.belt = path.belts[i_I];
						}
						else if (future__distance_between_payload_and_terminal <= 0f)
						{
							// move to machine //
							if (payload.belt.exit_flow_type != C.NONE__flow)
							{

								if (payload.belt.exit_flow_TILE_LET_index != C.none)
								{

									LET let = STORE.MACHINE__1D[payload.belt.exit_flow_TILE_index].
												  LET_1D[payload.belt.exit_flow_TILE_LET_index];


									if (let.payload == C.none)
									{
										bool resource_type_match = (let.resource_type_allowed == payload.resource__type) ||
																   (let.resource_type_allowed == C.any__payload);
										//
										if (resource_type_match)
										{
											// add payload to inlet
											let.payload = payload.resource__type;
											

											// remove payload from ( _RENDER_ , STORE ) , (path.PAYLOADS) //
											_RENDER_.REMOVE__PayLoad(payload);
											//

											STORE.PAYLOADS.Remove(payload);
											path.payloads.RemoveAt(0);
											// remove payload from ( _RENDER_ , STORE ) , (path.PAYLOADS) //

										}
										//
									}


								}



							}
							// move to machine //

						}


					}


				}
				//



			}





		}


		#region ad
		public static void circular_move(PATH path)
		{
			// minimum 4 tiles to be circular path

			int start_belt__payload = path.belts[0].payload;
			// remove the saved start payload
			path.belts[0].payload = C.none__payload;


			for (int i0 = path.belts.Count - 1; i0 >= 1; i0 -= 1)
			{
				path.belts[(i0 + 1) % path.belts.Count].payload = path.belts[i0].payload;
				path.belts[i0].payload = C.none__payload;
			}

			path.belts[1].payload = start_belt__payload;


		}

		public static void circular_move__payload(PATH path)
		{
			// minimum 4 tiles to be circular path

			for (int i0 = 0; i0 < path.payloads.Count; i0 += 1)
			{
				path.payloads[i0].t = (path.payloads[i0].t + PayLoad.move_increment) % path.belts.Count;

				int i_I = (int)path.payloads[i0].t;
				path.payloads[i0].belt = path.belts[i_I];
			}

		}
		#endregion

	}
	#endregion



	/*

		CONVEYOR_BELT / MACHINE
			create						  static
			move						  this
			rotate						  this
			remove						  this
			DRAW_BELTS(L<int[]> P);		  static


		COMBINER__MACHINE - index loop receive from inlet_payloads
		SPLITTER__MACHINE - index loop release to the outley__PATH(CONVEYOR_BELT)

	*/







	public static class STORE
	{
		public static TILE[][] GRID;

		public static List<CONVEYOR_BELT> CONVEYOR_BELT__1D;
		public static List<MACHINE> MACHINE__1D;

		public static List<PATH> PATHS;

		public static List<PayLoad> PAYLOADS;


		public static int[] dimension;
		public static void INITIALIZE()
		{
			CREATE_GRID();
		}



		// ORDER_OF_CALCULATION.PERFORM() is used instead

		public static void UPDATE__CONVEYOR_BELT__CONFIGURATIONS__and__PATHS_CALCULATION()
		{
			PATH.CALCULATE_each__CONVEYOR_BELT__CONFIGURAIONS__IN_ORDER();
			PATH.CALCULATE_PATH__for_each__conveyor_belt__discontinuity__of__flow();
			//
			PATH.RECALCULATE__and__assign__payload_distance__for_a_new_path();




		}



		#region CREATE_GRID
		static void CREATE_GRID()
		{
			int w = dimension[0],
				h = dimension[1];

			STORE.GRID = new TILE[h][];
			for (int y = 0; y < h; y += 1)
			{
				GRID[y] = new TILE[w];

				for (int x = 0; x < w; x += 1)
				{
					//
					GRID[y][x] = new TILE()
					{
						TILE_TYPE = C.EMPTY__tile,
						TILE_INDEX_in_HOLDER = C.none
					};
					//
				}
			}


			CONVEYOR_BELT__1D = new List<CONVEYOR_BELT>();
			MACHINE__1D = new List<MACHINE>();
			PATHS = new List<PATH>();

			PAYLOADS = new List<PayLoad>();

		}
		#endregion




	}


	public class PATH
	{
		public List<CONVEYOR_BELT> belts;
		public List<PayLoad> payloads;


		// TODO : circular path
		public int path_type;
		public float path_limit;




		// USED IN ORDER OF CALCULATION
		#region  USED IN ORDER OF CALCULATION
		//// CALCULATION ////

		#region CALCULATION OF CONVEYOR_BELT IN ORDER
		public static void CALCULATE_each__CONVEYOR_BELT__CONFIGURAIONS__IN_ORDER()
		{

			for (int i0 = 0; i0 < STORE.CONVEYOR_BELT__1D.Count; i0 += 1)
			{
				CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[i0];
				belt.CALCULATE__linkage_type__enter_flow();

				// bezier_curve //
				belt.CALCULATE__BEZIER_CURVE();
				// bezier_curve //
			}

			for (int i0 = 0; i0 < STORE.CONVEYOR_BELT__1D.Count; i0 += 1)
			{
				CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[i0];
				belt.CALCULATE__exit_flow();
			}


		}

		#endregion



		#region CALCUATION OF EACH PATH
		public static void CALCULATE_PATH__for_each__conveyor_belt__discontinuity__of__flow()
		{
			STORE.PATHS = new List<PATH>();

			bool[] explored = new bool[STORE.CONVEYOR_BELT__1D.Count];

			#region INITIALIZE_explored
			for (int i0 = 0; i0 < STORE.CONVEYOR_BELT__1D.Count; i0 += 1)
			{
				//
				explored[i0] = false;
			}
			#endregion


			int iter_0 = 0;
			while (true)
			{
				iter_0 += 1;
				if (iter_0 > 1000) { Debug.Log("iter_0 .... stuck"); break; }

				#region Weather all_belts_explored ?
				bool all_belts_explored = true;

				for (int i0 = 0; i0 < explored.Length; i0 += 1)
				{
					//
					if (explored[i0] == false) { all_belts_explored = false; break; }
					//
				}

				if (all_belts_explored) { break; }
				#endregion


				CONVEYOR_BELT start_belt = null;


				int start_belt__index__to_calculate_circular_path = C.none;
				int path_type = C.linear_path;

				#region find a random not explored CONVEYOR_BELT__tile
				for (int i0 = 0; i0 < STORE.CONVEYOR_BELT__1D.Count; i0 += 1)
				{
					//
					if (!explored[i0])
					{
						start_belt = STORE.CONVEYOR_BELT__1D[i0];
						// explored //
						explored[i0] = true;
						// explored //

						start_belt__index__to_calculate_circular_path = i0;

						break;
					}
					//

				}
				#endregion


				#region find the start_belt of path // until enter is not CONVEYOR_BELT__tile
				int iter_1 = 0;
				while (true)
				{
					iter_1 += 1;
					if (iter_1 > 1000) { Debug.Log("iter_1 .... stuck"); break; }
					if (start_belt.enter_flow_type != C.CONVEYOR_BELT__flow)
						break;



					if (start_belt.enter_flow_TILE_index == start_belt__index__to_calculate_circular_path)
					{
						//
						start_belt = STORE.CONVEYOR_BELT__1D[start_belt.enter_flow_TILE_index];
						path_type = C.circular_path;
						break;
					}

					//
					start_belt = STORE.CONVEYOR_BELT__1D[start_belt.enter_flow_TILE_index];
				}

				#endregion



				PATH path = new PATH()
				{
					belts = new List<CONVEYOR_BELT>() { start_belt },
					payloads = new List<PayLoad>(),
					path_type = path_type
				};
				//


				#region path from start_belt to end_belt

				CONVEYOR_BELT end_belt = start_belt;
				// 
				int iter_2 = 0;

				while (true)
				{
					iter_2 += 1;
					if (iter_2 > 1000) { Debug.Log("iter_2 .... stuck"); break; }


					if (path.path_type == C.circular_path)
					{
						if (end_belt.exit_flow_TILE_index == start_belt__index__to_calculate_circular_path)
						{
							break;
						}
						//

						// explored //
						// explored[end_belt.exit_flow_TILE_index] = true;
						// explored //

						end_belt = STORE.CONVEYOR_BELT__1D[end_belt.exit_flow_TILE_index];
						path.belts.Add(end_belt);
					}
					//

					else if (path.path_type == C.linear_path)
					{
						if (end_belt.exit_flow_type != C.CONVEYOR_BELT__flow)
						{
							break;
						}

						// explored //
						// explored[end_belt.exit_flow_TILE_index] = true;
						// explored //

						end_belt = STORE.CONVEYOR_BELT__1D[end_belt.exit_flow_TILE_index];
						path.belts.Add(end_belt);

					}
				}
				#endregion
				//
				STORE.PATHS.Add(path);



				for (int i1 = 0; i1 < path.belts.Count; i1 += 1)
				{
					CONVEYOR_BELT belt = path.belts[i1];
					explored[STORE.CONVEYOR_BELT__1D.IndexOf(belt)] = true;

					belt.PATH_index = STORE.PATHS.Count - 1;
					belt.belt_index_in__path = i1;
				}



				string str = "";
				for (int i0 = 0; i0 < explored.Length; i0 += 1)
				{
					str += explored[i0] + " - ";
				}
				// Debug.Log(str);

			}







		}

		#endregion

		//// CALCULATION //// 
		#endregion



		// PAYLOAD //

		//// FUNCTIONALITY ////

		/*
			// return false if limit_Distance is close
			public bool Add_PayLoad_from__machine(int resource_type)
			
			// should be called after creating every PATH
			public static void RECALCULATE__and__assign__payload_distance__for_a_new_path()
			public static void FUNCTIONALITY_MOVE_RESOURCES__PayLoad_METHOD_()

		*/


		// PAYLOAD RE-ASSIGN
		#region  USED IN ORDER OF CALCULATION
		// USED IN ORDER OF CALCULATION
		// should be called after creating every PATH
		public static void RECALCULATE__and__assign__payload_distance__for_a_new_path()
		{




			for (int i0 = 0; i0 < STORE.PAYLOADS.Count; i0 += 1)
			{
				PayLoad payload = STORE.PAYLOADS[i0];
				PATH path = STORE.PATHS[payload.belt.PATH_index];


				float dt = payload.t - (int)(payload.t);
				float new_t = payload.belt.belt_index_in__path + dt;
				payload.t = new_t;

			}


			//
			for (int i0 = 0; i0 < STORE.PATHS.Count; i0 += 1)
			{
				STORE.PATHS[i0].payloads = new List<PayLoad>();
			}



			for (int i0 = 0; i0 < STORE.PAYLOADS.Count; i0 += 1)
			{
				PayLoad payload = STORE.PAYLOADS[i0];
				PATH path = STORE.PATHS[STORE.PAYLOADS[i0].belt.PATH_index];


				if (path.payloads.Count == 0)
				{
					path.payloads.Add(payload);
				}
				else
				{
					int i1 = 0;
					for (; i1 < path.payloads.Count; i1 += 1)
					{
						if (payload.t > path.payloads[i1].t)
						{
							break;
						}
					}



					if (i1 == path.payloads.Count) { path.payloads.Add(payload); }
					else { path.payloads.Insert(i1, payload); }


				}


			}





		} 
		#endregion





		#region FUNCTIONALITY__MOVE_RESOURCES __PAYLOAD

		// return false if limit_Distance is close
		public bool Add_PayLoad_from__machine(int resource_type)
		{
			if(this.payloads.Count != 0)
			{
				if(payloads[payloads.Count - 1].t < PayLoad.proximity)
				{
					// last payload distance with begining of path is less then proximity
					return false;
				}
			}



			PayLoad payload = new PayLoad()
			{
				resource__type = resource_type,

				t = 0f,
				belt = this.belts[0]
			};

			this.payloads.Add(payload);
			STORE.PAYLOADS.Add(this.payloads[this.payloads.Count - 1]);



			// payload has been added
			return true;
		}



		#region USED IN ORDER__OF__MOVEMENT_OF_PAYLOAD
		// move payload based on proximity with next payload
		public static void FUNCTIONALITY_MOVE_RESOURCES__PayLoad_METHOD_()
		{

			for (int i0 = 0; i0 < STORE.PATHS.Count; i0 += 1)
			{
				PATH path = STORE.PATHS[i0];
				if (path.path_type == C.circular_path) { circular_move__payload(path); continue; }



				path.path_limit = path.belts.Count; // >= limit //


				//
				for (int i1 = 0; i1 < path.payloads.Count; i1 += 1)
				{
					PayLoad payload = path.payloads[i1];


					if (i1 != 0)
					{
						//
						float next_distance_t_of_payload = payload.t + PayLoad.move_increment;

						float future__distance_between_payloads = path.payloads[i1 - 1].t - next_distance_t_of_payload;
						if (future__distance_between_payloads >= PayLoad.proximity)
						{
							//
							payload.t = next_distance_t_of_payload;

							int i_I = (int)payload.t;
							payload.belt = path.belts[i_I];
						}
						//
					}
					else if (i1 == 0)
					{
						float next_distance_t_of_payload = payload.t + PayLoad.move_increment;

						float future__distance_between_payload_and_terminal = path.path_limit - next_distance_t_of_payload;

						if (future__distance_between_payload_and_terminal > 0f)
						{
							//
							payload.t = next_distance_t_of_payload;

							int i_I = (int)payload.t;
							payload.belt = path.belts[i_I];
						}
						else if (future__distance_between_payload_and_terminal <= 0f)
						{
							// move to machine //
							if (payload.belt.exit_flow_type != C.NONE__flow)
							{

								if (payload.belt.exit_flow_TILE_LET_index != C.none)
								{
									LET let = STORE.MACHINE__1D[payload.belt.exit_flow_TILE_index].
												  LET_1D[payload.belt.exit_flow_TILE_LET_index];


									if (let.payload == C.none)
									{
										if (let.resource_type_allowed == payload.resource__type)
										{
											STORE.MACHINE__1D[payload.belt.exit_flow_TILE_index].
													  LET_1D[payload.belt.exit_flow_TILE_LET_index].payload = payload.resource__type;

											//
											_RENDER_.REMOVE__PayLoad(payload);
											//
											path.payloads.RemoveAt(0);
										}
									}

								}

							}
							// move to machine //


						}


					}


				}
				//



			}


		} 
		#endregion





		#endregion


		#region ad
		public static void circular_move(PATH path)
		{
			// minimum 4 tiles to be circular path

			int start_belt__payload = path.belts[0].payload;
			// remove the saved start payload
			path.belts[0].payload = C.none__payload;


			for (int i0 = path.belts.Count - 1; i0 >= 1; i0 -= 1)
			{
				path.belts[(i0 + 1) % path.belts.Count].payload = path.belts[i0].payload;
				path.belts[i0].payload = C.none__payload;
			}

			path.belts[1].payload = start_belt__payload;


		}

		public static void circular_move__payload(PATH path)
		{
			// minimum 4 tiles to be circular path

			for (int i0 = 0; i0 < path.payloads.Count; i0 += 1)
			{
				path.payloads[i0].t = (path.payloads[i0].t + PayLoad.move_increment) % path.belts.Count;

				int i_I = (int)path.payloads[i0].t;
				path.payloads[i0].belt = path.belts[i_I];
			}

		}
		#endregion

		//// FUNCTIONALITY ////

		// PAYLOAD //











	}



	public class PayLoad
	{
		public float t = 0f; // from start of the path //

		public static float proximity = 1f;

		// mat_offset = 0.01f
		public static float move_increment = 0.012f;


		public CONVEYOR_BELT belt;

		public int resource__type = C.none;
	}



	public class TILE
	{
		/*
			CONVEYOR_BELT
			EMPTY
			NONE

			TODO : MACHINE
			TODO : NATURAL_RESOURCE
		*/
		public int TILE_TYPE = C.EMPTY__tile;
		public int TILE_INDEX_in_HOLDER = C.none;
	}


	//

	public class CONVEYOR_BELT
	{

		public int state_of_tile;                            // r , f , l , b [absolute]
		public int linkage_type;                             // r_to_f , l_to_f , b_to_f  [relative to state of tile]


		public int enter_flow_type;                          // CONVEYOR_BELT , MACHINE , none
		public int exit_flow_type;                           // CONVEYOR_BELT , MACHINE , none 


		public int enter_flow_TILE_index;                    // index in L<>
		public int enter_flow_TILE_LET_index;                // index in L<LET> (if enter_flow_type = MACHINE)


		public int exit_flow_TILE_index;                     // index in L<>
		public int exit_flow_TILE_LET_index;                 // index in L<LET> (if exit_flow_type = MACHINE)



		public int[] global_pos;                             // v2 global


		// not individual payload
		public int payload;                                  // resource_type , none



		public int PATH_index;                              // index of path : gotta be somthng
		public int belt_index_in__path;












		#region // METHID - 0 //

		public void CLASSIFY__linkage_type()
		{
			// using state_of_tile , C.DIRS // local : f , l , b , r
			int[] state_of_tile__neighbour__1D = new int[4];


			// TODO
			// int[] tile_let_index_of_machine_tile = new int[4] { C.none, C.none, C.none, C.none };


			// STORE //
			for (int i0 = 0; i0 < 4; i0 += 1)
			{
				int[] dir = C.DIRS[(this.state_of_tile + i0) % 4];

				int[] pos = new int[2]
				{
					this.global_pos[0] + dir[0],
					this.global_pos[1] + dir[1],
				};


				TILE tile = STORE.GRID[pos[1]][pos[0]];




				if (tile.TILE_TYPE == C.CONVEYOR_BELT__tile)
					state_of_tile__neighbour__1D[i0] = STORE.CONVEYOR_BELT__1D[tile.TILE_INDEX_in_HOLDER].state_of_tile;
				//
				else if (tile.TILE_TYPE == C.MACHINE__tile)
				{
					// TODO
					// based on one of inlet , outlet associated with curr tile, tile state shall be : r , f , l , b __state
					// or else its a none__state

					//store the let index of tile, if found associated 
				}
				//
				else
					state_of_tile__neighbour__1D[i0] = C.none__state;

			}
			// STORE //



			// CLASSIFY //
			bool r_to_f__states_of_neighbouring =
				// (state_of_tile__neighbour__1D[0]  can be anything
				(state_of_tile__neighbour__1D[3] == (state_of_tile + 1) % 4) &&
				(state_of_tile__neighbour__1D[1] != (state_of_tile + 3) % 4) &&
				(state_of_tile__neighbour__1D[2] != (state_of_tile + 0) % 4);

			bool l_to_f__states_of_neighbouring =
				// (state_of_tile__neighbour__1D[0]  can be anything
				(state_of_tile__neighbour__1D[1] == (state_of_tile + 3) % 4) &&
				(state_of_tile__neighbour__1D[3] != (state_of_tile + 1) % 4) &&
				(state_of_tile__neighbour__1D[2] != (state_of_tile + 0) % 4);

			bool b_to_f__states_of_neighbouring =
				// (state_of_tile__neighbour__1D[0]  can be anything
				(state_of_tile__neighbour__1D[2] == (state_of_tile + 0) % 4);
			// (state_of_tile__neighbour__1D[1]  can be anything
			// (state_of_tile__neighbour__1D[3]  can be anything



			this.linkage_type = (r_to_f__states_of_neighbouring) ? C.r_to_f__linkage :
								(l_to_f__states_of_neighbouring) ? C.l_to_f__linkage :
								(b_to_f__states_of_neighbouring) ? C.b_to_f__linkage : C.none__linkage;


			// CLASSIFY //
		}


		//
		public void CLASSIFY_enter_flow__tile_type__tile_index_in_holder_()
		{

			TILE[] tile_1D = new TILE[4];

			for (int i0 = 1; i0 < 4; i0 += 1)
			{
				int[] dir = C.DIRS[(this.state_of_tile + i0) % 4];

				int[] pos = new int[2]
				{
					this.global_pos[0] + dir[0],
					this.global_pos[1] + dir[1],
				};


				tile_1D[i0] = STORE.GRID[pos[1]][pos[0]];
			}



			if (this.linkage_type == C.r_to_f__linkage)
			{
				// CONVEYOR_BELT__tile //
				if (tile_1D[3].TILE_TYPE == C.CONVEYOR_BELT__tile)
				{
					//
					enter_flow_type = tile_1D[3].TILE_TYPE;
					enter_flow_TILE_index = tile_1D[3].TILE_INDEX_in_HOLDER;
				}
				// CONVEYOR_BELT__tile //



				// MACHINE__tile //
				else if (tile_1D[3].TILE_TYPE == C.MACHINE__tile)
				{
					// TODO
				}
				// MACHINE__tile //

			}

			else if (this.linkage_type == C.l_to_f__linkage)
			{
				// CONVEYOR_BELT__tile //
				if (tile_1D[1].TILE_TYPE == C.CONVEYOR_BELT__tile)
				{
					enter_flow_type = tile_1D[1].TILE_TYPE;
					enter_flow_TILE_index = tile_1D[1].TILE_INDEX_in_HOLDER;
				}
				// CONVEYOR_BELT__tile //




				// MACHINE__tile //
				else if (tile_1D[1].TILE_TYPE == C.MACHINE__tile)
				{
					// TODO
				}
				// MACHINE__tile //

			}
			else if (this.linkage_type == C.b_to_f__linkage)
			{

				// CONVEYOR_BELT__tile //
				if (tile_1D[2].TILE_TYPE == C.CONVEYOR_BELT__tile)
				{
					enter_flow_type = tile_1D[2].TILE_TYPE;
					enter_flow_TILE_index = tile_1D[2].TILE_INDEX_in_HOLDER;
				}
				// CONVEYOR_BELT__tile //


				// MACHINE__tile //
				else if (tile_1D[2].TILE_TYPE == C.MACHINE__tile)
				{
					// TODO
				}
				// MACHINE__tile //

			}



			else if (this.linkage_type == C.none__linkage)
			{
				enter_flow_type = C.NONE__flow;
				enter_flow_TILE_index = C.none;
			}

			// CLASSIFY //



		}
		//


		public void CLASSIFY_exit_flow__tile_type__tile_index_in_holder_()
		{

			int[] dir = C.DIRS[(this.state_of_tile + 0) % 4];

			int[] pos = new int[2]
			{
				this.global_pos[0] + dir[0],
				this.global_pos[1] + dir[1],
			};

			TILE tile = STORE.GRID[pos[1]][pos[0]];



			// does not depend on linkage_type //
			// depend only on the local f neighbour tile //
			// CLASSIFY //
			if (tile.TILE_TYPE == C.CONVEYOR_BELT__tile)
			{
				CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[tile.TILE_INDEX_in_HOLDER];


				///  REQUIRE linkage_type to be classified ///
				//
				if (belt.state_of_tile == this.state_of_tile)
				{
					this.exit_flow_type = C.CONVEYOR_BELT__flow;
					this.exit_flow_TILE_index = tile.TILE_INDEX_in_HOLDER;
				}


				else if (belt.state_of_tile == (this.state_of_tile + 3) % 4)
				{
					if (belt.linkage_type == C.r_to_f__linkage)
					{
						this.exit_flow_type = C.CONVEYOR_BELT__tile;
						this.exit_flow_TILE_index = tile.TILE_INDEX_in_HOLDER;
					}
					else
					{
						this.exit_flow_type = C.NONE__flow;
						this.exit_flow_TILE_index = tile.TILE_INDEX_in_HOLDER;
					}
				}

				else if (belt.state_of_tile == (this.state_of_tile + 1) % 4)
				{
					if (belt.linkage_type == C.l_to_f__linkage)
					{
						this.exit_flow_type = C.CONVEYOR_BELT__tile;
						this.exit_flow_TILE_index = tile.TILE_INDEX_in_HOLDER;
					}
					else
					{
						this.exit_flow_type = C.NONE__flow;
						this.exit_flow_TILE_index = tile.TILE_INDEX_in_HOLDER;
					}
				}


				else
				{
					this.exit_flow_type = C.NONE__flow;
					this.exit_flow_TILE_index = tile.TILE_INDEX_in_HOLDER;
				}



			}
			else if (tile.TILE_TYPE == C.MACHINE__tile)
			{

				// TODO

			}






			// CLASSIFY //


		}
		#endregion


		#region CALCULATE_NEIGHBOURS_CONFIGURATION

		public int[][] CALCULATE_NEIGHBOURS_CONFIGURATION()
		{

			/*
				  f   l   b   r ( local )
				[   ,   ,   ,   ] -> state_of_tile
				[   ,   ,   ,   ] -> TYPE_of_TILE
				[   ,   ,   ,   ] -> TILE_INDEX
				[   ,   ,   ,   ] -> MACHINE_LET_TILE_INDEX
			*/


			int[][] NEIGHBOURS_CONFIGURATION = new int[4][]
			{
				new int[4],
				new int[4],
				new int[4],
				new int[4],
			};


			// all 4 DIRS local to state_of_tile //
			for (int i0 = 0; i0 < 4; i0 += 1)
			{

				// global_pos of tile //
				int[] pos = new int[2]
				{
					this.global_pos[0] + C.DIRS[ (this.state_of_tile + i0 ) % 4][0],
					this.global_pos[1] + C.DIRS[ (this.state_of_tile + i0 ) % 4][1],
				};
				// global_pos of tile //


				//

				TILE tile = STORE.GRID[pos[1]][pos[0]];

				if (tile.TILE_TYPE == C.CONVEYOR_BELT__tile)
				{
					CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[tile.TILE_INDEX_in_HOLDER];
					//
					NEIGHBOURS_CONFIGURATION[0][i0] = belt.state_of_tile;
					NEIGHBOURS_CONFIGURATION[1][i0] = C.CONVEYOR_BELT__tile;
					NEIGHBOURS_CONFIGURATION[2][i0] = tile.TILE_INDEX_in_HOLDER;
					NEIGHBOURS_CONFIGURATION[3][i0] = C.none;

				}

				else if (tile.TILE_TYPE == C.MACHINE__tile)
				{
					MACHINE machine = STORE.MACHINE__1D[tile.TILE_INDEX_in_HOLDER];


					int let_index = C.none;
					// let_index classify based on tile_associated
					//
					for (int i1 = 0; i1 < machine.LET_1D.Count; i1 += 1)
					{
						LET let = machine.LET_1D[i1];


						// weather let_tile_associated is curr tile, than let_index = i1


						// exclude block_let type //
						if (let.type_of_let != C.block_let)
						{
							// let
							int[] let__global_pos = new int[2]
							{
								machine.global_pos[0] + let.local_pos[0],
								machine.global_pos[1] + let.local_pos[1],
							};

							// let is at the pos (neighbour pos) 
							if (let__global_pos[0] == pos[0] &&
								let__global_pos[1] == pos[1])
							{
								// let_tile_associated
								int[] let_tile_associated__global_pos = new int[2]
								{
									machine.global_pos[0] + let.local_pos_of_tile_associated[0],
									machine.global_pos[1] + let.local_pos_of_tile_associated[1],
								};

								// let_tile_associated is curr tile
								if (let_tile_associated__global_pos[0] == this.global_pos[0] &&
									 let_tile_associated__global_pos[1] == this.global_pos[1])
								{
									let_index = i1;
									break;
								}
							}
							// let is at the pos (neighbour pos) 
						}


						// weather let_tile_associated is curr tile, than let_index = i1

					}


					// not found //
					if (let_index == C.none)
					{
						NEIGHBOURS_CONFIGURATION[0][i0] = C.none__state;
						NEIGHBOURS_CONFIGURATION[1][i0] = C.MACHINE__tile;
						NEIGHBOURS_CONFIGURATION[2][i0] = tile.TILE_INDEX_in_HOLDER;
						NEIGHBOURS_CONFIGURATION[3][i0] = C.none;
					}
					else
					{

						NEIGHBOURS_CONFIGURATION[0][i0] = machine.LET_1D[let_index].state_of_tile;
						NEIGHBOURS_CONFIGURATION[1][i0] = C.MACHINE__tile;
						NEIGHBOURS_CONFIGURATION[2][i0] = tile.TILE_INDEX_in_HOLDER;
						NEIGHBOURS_CONFIGURATION[3][i0] = let_index;
					}

				}

				else
				{
					NEIGHBOURS_CONFIGURATION[0][i0] = C.none__state;
					NEIGHBOURS_CONFIGURATION[1][i0] = C.NONE__tile;
					NEIGHBOURS_CONFIGURATION[2][i0] = C.none;
					NEIGHBOURS_CONFIGURATION[3][i0] = C.none;
				}

				//
			}



			return NEIGHBOURS_CONFIGURATION;
		}

		#endregion




		// TODO ---- DONE
		/*
		 not used anywhere in impleted so far 
			(could be used in indexing inside NEIGHBOURS_CONFIGURATION[][ index ] )
			(could be used as offset from state_of_tile while rotating dir)
		 
		will be used in GRID__TILE_DRAW

		  C.
			f__state = 0
			l__state = 1
			b__state = 2
			r__state = 3

		  C.DIRS
			[ +1 , 0 ]
			[  0 ,+1 ]
			[ -1 , 0 ]
			[  0 ,-1 ]
		*/





		public void CALCULATE__linkage_type__enter_flow()
		{
			int[][] NEIGHBOURS_CONFIGURATION = CALCULATE_NEIGHBOURS_CONFIGURATION();

			/*
				  f   l   b   r ( local )
				[   ,   ,   ,   ] -> state_of_tile
				[   ,   ,   ,   ] -> TYPE_of_TILE
				[   ,   ,   ,   ] -> TILE_INDEX
				[   ,   ,   ,   ] -> MACHINE_LET_TILE_INDEX
			*/



			int[] absolute__state_of_tile__1D = NEIGHBOURS_CONFIGURATION[0];

			bool r_to_f__linkage =
									//  state_of_tile__1D[0] can be anything
									(absolute__state_of_tile__1D[3] == (this.state_of_tile + 1) % 4) &&
									(absolute__state_of_tile__1D[1] != (this.state_of_tile + 3) % 4) &&
									(absolute__state_of_tile__1D[2] != (this.state_of_tile + 0) % 4);


			bool l_to_f__linkage =
									//  state_of_tile__1D[0] can be anything
									(absolute__state_of_tile__1D[1] == (this.state_of_tile + 3) % 4) &&
									(absolute__state_of_tile__1D[3] != (this.state_of_tile + 1) % 4) &&
									(absolute__state_of_tile__1D[2] != (this.state_of_tile + 0) % 4);

			bool b_to_f__linkage =
									//  state_of_tile__1D[0] can be anything
									//  state_of_tile__1D[1] can be anything
									//  state_of_tile__1D[3] can be anything
									(absolute__state_of_tile__1D[2] == (this.state_of_tile + 0) % 4);



			if (r_to_f__linkage)
			{
				this.linkage_type = C.r_to_f__linkage;

				this.enter_flow_type = NEIGHBOURS_CONFIGURATION[1][3];
				this.enter_flow_TILE_index = NEIGHBOURS_CONFIGURATION[2][3];
				this.enter_flow_TILE_LET_index = NEIGHBOURS_CONFIGURATION[3][3];

			}
			else if (l_to_f__linkage)
			{
				this.linkage_type = C.l_to_f__linkage;

				this.enter_flow_type = NEIGHBOURS_CONFIGURATION[1][1];
				this.enter_flow_TILE_index = NEIGHBOURS_CONFIGURATION[2][1];
				this.enter_flow_TILE_LET_index = NEIGHBOURS_CONFIGURATION[3][1];
			}
			else if (b_to_f__linkage)
			{
				this.linkage_type = C.b_to_f__linkage;

				this.enter_flow_type = NEIGHBOURS_CONFIGURATION[1][2];
				this.enter_flow_TILE_index = NEIGHBOURS_CONFIGURATION[2][2];
				this.enter_flow_TILE_LET_index = NEIGHBOURS_CONFIGURATION[3][2];
			}
			else
			{
				this.linkage_type = C.none__linkage;

				this.enter_flow_type = C.NONE__flow;
				this.enter_flow_TILE_index = C.none;
				this.enter_flow_TILE_LET_index = C.none;
			}



		}

		public void CALCULATE__exit_flow()
		{
			int[][] NEIGHBOURS_CONFIGURATION = CALCULATE_NEIGHBOURS_CONFIGURATION();

			/*
				  f   l   b   r ( local )
				[   ,   ,   ,   ] -> state_of_tile
				[   ,   ,   ,   ] -> TYPE_of_TILE
				[   ,   ,   ,   ] -> TILE_INDEX
				[   ,   ,   ,   ] -> MACHINE_LET_TILE_INDEX
			*/

			// linkage_type = [ relative to f ] r_to_f , l_to_f , b_to_f , none



			int absolute__state_of_tile__f = NEIGHBOURS_CONFIGURATION[0][0];

			if (absolute__state_of_tile__f == (this.state_of_tile + 0) % 4)
			{
				// CONVEYOR_BELT or MACHINE __TILE

				this.exit_flow_type = NEIGHBOURS_CONFIGURATION[1][0];
				this.exit_flow_TILE_index = NEIGHBOURS_CONFIGURATION[2][0];
				this.exit_flow_TILE_LET_index = NEIGHBOURS_CONFIGURATION[3][0];

			}
			else if (absolute__state_of_tile__f == (this.state_of_tile + 3) % 4)
			{
				//CONVEYOR_BELT __TILE

				CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[NEIGHBOURS_CONFIGURATION[2][0]];
				if (belt.linkage_type == C.r_to_f__linkage)
				{
					this.exit_flow_type = NEIGHBOURS_CONFIGURATION[1][0];
					this.exit_flow_TILE_index = NEIGHBOURS_CONFIGURATION[2][0];
					this.exit_flow_TILE_LET_index = NEIGHBOURS_CONFIGURATION[3][0];
				}
				else
				{
					this.exit_flow_type = C.NONE__tile;
					this.exit_flow_TILE_index = C.none;
					this.exit_flow_TILE_LET_index = C.none;
				}


			}
			else if (absolute__state_of_tile__f == (this.state_of_tile + 1) % 4)
			{
				//CONVEYOR_BELT __TILE

				CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[NEIGHBOURS_CONFIGURATION[2][0]];
				if (belt.linkage_type == C.l_to_f__linkage)
				{
					this.exit_flow_type = NEIGHBOURS_CONFIGURATION[1][0];
					this.exit_flow_TILE_index = NEIGHBOURS_CONFIGURATION[2][0];
					this.exit_flow_TILE_LET_index = NEIGHBOURS_CONFIGURATION[3][0];
				}
				else
				{
					this.exit_flow_type = C.NONE__tile;
					this.exit_flow_TILE_index = C.none;
					this.exit_flow_TILE_LET_index = C.none;
				}

			}
			else
			{
				//CONVEYOR_BELT or MACHINE or NONE __TILE
				this.exit_flow_type = C.NONE__tile;
				this.exit_flow_TILE_index = C.none;
				this.exit_flow_TILE_LET_index = C.none;
			}



		}

		/*
			0. call CALCULATE__linkage_type__enter_flow for every conveyor_belt so the linkage_type is found
			1. call CALCULATE__exit_flow
		*/




		public List<Vector2> bezier_curve;
		//
		#region CALCULATE__BEZIER_CURVE
		// after linkage_type is calculated //

		public void CALCULATE__BEZIER_CURVE()
		{
			if (this.linkage_type == C.b_to_f__linkage || this.linkage_type == C.none__linkage)
			{
				Vector2 dir_f = new Vector2(C.DIRS[this.state_of_tile][0], C.DIRS[this.state_of_tile][1]);
				//
				bezier_curve = new List<Vector2>()
				{
					-1 * dir_f * 0.5f,
					-1 * dir_f * 0.159f,
					+1 * dir_f * 0.159f,
					+1 * dir_f * 0.5f,
				};
				//
			}

			else if (this.linkage_type == C.r_to_f__linkage)
			{
				Vector2 dir_f = new Vector2(C.DIRS[this.state_of_tile][0], C.DIRS[this.state_of_tile][1]);
				Vector2 dir_r = new Vector2
				(
					C.DIRS[(this.state_of_tile + 3) % 4][0],
					C.DIRS[(this.state_of_tile + 3) % 4][1]
				);

				//
				bezier_curve = new List<Vector2>()
				{
					+1 * dir_r * 0.5f,
					lerp(+1 * dir_r * 0.5f , Vector2.zero, 0.554f),
					lerp(Vector2.zero, +1 * dir_f * 0.5f ,  0.554f),
					+1 * dir_f * 0.5f,
				};
				//
			}

			else if (this.linkage_type == C.l_to_f__linkage)
			{
				Vector2 dir_f = new Vector2(C.DIRS[this.state_of_tile][0], C.DIRS[this.state_of_tile][1]);
				Vector2 dir_l = new Vector2
				(
					C.DIRS[(this.state_of_tile + 1) % 4][0],
					C.DIRS[(this.state_of_tile + 1) % 4][1]
				);

				//
				bezier_curve = new List<Vector2>()
				{
					+1 * dir_l * 0.5f,
					lerp(+1 * dir_l * 0.5f , Vector2.zero, 0.554f),

					lerp(Vector2.zero, +1 * dir_f * 0.5f ,  0.554f),
					+1 * dir_f * 0.5f,
				};
				//
			}


		}

		static Vector2 lerp(Vector2 a, Vector2 b, float t)
		{
			Vector2 n = b - a;
			return a + n * t;
		}



		// after linkage_type is calculated //
		#endregion




		// ONLY GET from STORE, NO MODIFICATION TO STORE IS DONE //

		public static CONVEYOR_BELT CREATE(int[] global_pos , int state_of_tile)
		{
			CONVEYOR_BELT belt = new CONVEYOR_BELT()
			{
				global_pos = global_pos,
				state_of_tile = state_of_tile,
				payload = C.none__payload,


				enter_flow_TILE_index = C.none,
				enter_flow_type = C.NONE__flow,
				enter_flow_TILE_LET_index = C.none,

				exit_flow_TILE_index = C.none,
				exit_flow_type = C.NONE__flow,
				exit_flow_TILE_LET_index = C.none,
			};

			return belt;
		}


		public void ROTATE()
		{
			this.state_of_tile = (this.state_of_tile + 1) % 4;
		}

		public void REMOVE()
		{
			//
			
			//
		}
		// ONLY GET from STORE, NO MODIFICATION TO STORE IS DONE //


	}


	public class MACHINE
	{
		public int[] global_pos;                             // v2 global

		public List<LET> LET_1D;                             // L<LET>

		public int TYPE_OF_MACHINE;                          // PRODUCER , CONVERTER , COMBINER


		public int rotation = 0;





		// CALCULATE__MACHINE__LET__LINKED__WITH__CONVEYOR_BELT__of_each__MACHINE
		public void CALCULATE__MACHINE__EXIT_FLOW__for__each_tile()
		{
			//
			MACHINE machine = this;
			List<LET> LET_1D = machine.LET_1D;
			//

			for (int i0 = 0; i0 < LET_1D.Count; i0 += 1)
			{

				LET let = LET_1D[i0];
				let.exit_flow__conveyor_belt__index = C.none;

				int[] global_pos__let_assosiated_tile = new int[]
				{
					machine.global_pos[0] + let.local_pos_of_tile_associated[0],
					machine.global_pos[1] + let.local_pos_of_tile_associated[1],
				};



				for (int i1 = 0; i1 < STORE.CONVEYOR_BELT__1D.Count; i1 += 1)
				{
					CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[i1];

					//
					if (belt.global_pos[0] == global_pos__let_assosiated_tile[0] &&
						belt.global_pos[1] == global_pos__let_assosiated_tile[1])
					{
						if (belt.state_of_tile == (let.state_of_tile))
						{
							let.exit_flow__conveyor_belt__index = i1;
							break;
						}
						//
						else if (belt.state_of_tile == (let.state_of_tile + 1) % 4)
						{
							if (belt.linkage_type == C.l_to_f__linkage)
							{
								let.exit_flow__conveyor_belt__index = i1;
								break;
							}
						}
						//
						else if (belt.state_of_tile == (let.state_of_tile + 3) % 4)
						{
							if (belt.linkage_type == C.r_to_f__linkage)
							{
								let.exit_flow__conveyor_belt__index = i1;
								break;
							}
						}
						//
						else if (belt.state_of_tile == (let.state_of_tile + 2) % 4)
						{
							let.exit_flow__conveyor_belt__index = C.none;
							break;
						}


					}
					//
				}




			}

		}



		// ONLY GET from STORE, NO MODIFICATION TO STORE IS DONE //

		public static MACHINE CREATE(int[] global_pos, int TYPE_OF_MACHINE)
		{
			MACHINE machine = new MACHINE()
			{
				global_pos = global_pos,
				TYPE_OF_MACHINE = TYPE_OF_MACHINE,
			};

			//
			machine.LET_1D = LIBRARY(TYPE_OF_MACHINE);

			machine.resources_count = new int[C.TOTAL_resources_count];
			machine.inlet_index__to__explore = 0;
			machine.outlet_index__to__explore = 0;


			return machine;
		}

		public static List<LET> LIBRARY(int TYPE_OF_MACHINE)
		{

			if (TYPE_OF_MACHINE == C.PRODUCER)
			{
				return new List<LET>()
				{
					new LET()
					{
						local_pos = new int[2]{0, 0},
						type_of_let = C.outlet,

						local_pos_of_tile_associated = new int[2]{1, 0},
						state_of_tile = C.f__state,


						// to be calculated later //
						exit_flow__conveyor_belt__index = C.A__payload,
						// to be calculated later //


						resource_type_allowed = C.none,
						payload = C.none__payload
					}


				};



			}

			else if (TYPE_OF_MACHINE == C.COMBINER__machine)
			{
				#region BEFORE
				/*
				return new List<LET>()
				{
					new LET()
					{
						local_pos = new int[2]{0, 0},
						type_of_let = C.inlet,

						local_pos_of_tile_associated = new int[2]{0, -1},
						state_of_tile = C.l__state,


						// to be calculated later //
						exit_flow__conveyor_belt__index = C.none,
						// to be calculated later //


						resource_type_allowed = C.any__payload,
						payload = C.none
					},

					new LET()
					{
						local_pos = new int[2]{0, 0},
						type_of_let = C.inlet,

						local_pos_of_tile_associated = new int[2]{-1, 0},
						state_of_tile = C.f__state,


						// to be calculated later //
						exit_flow__conveyor_belt__index = C.none,
						// to be calculated later //


						resource_type_allowed = C.any__payload,
						payload = C.none
					},


					new LET()
					{
						local_pos = new int[2]{0, 0},
						type_of_let = C.inlet,

						local_pos_of_tile_associated = new int[2]{0, +1},
						state_of_tile = C.r__state,


						// to be calculated later //
						exit_flow__conveyor_belt__index = C.none,
						// to be calculated later //


						resource_type_allowed = C.any__payload,
						payload = C.none
					},


					new LET()
					{
						local_pos = new int[2]{0, 0},
						type_of_let = C.outlet,

						local_pos_of_tile_associated = new int[2]{+1, 0},
						state_of_tile = C.f__state,


						// to be calculated later //
						exit_flow__conveyor_belt__index = C.none,
						// to be calculated later //


						resource_type_allowed = C.any__payload,
						payload = C.none
					}

				};
				*/
				#endregion



				return new List<LET>()
				{
					new LET()
					{
						local_pos = new int[2]{0, -1},
						type_of_let = C.inlet,

						local_pos_of_tile_associated = new int[2]{-1, -1},
						state_of_tile = C.f__state,


						// to be calculated later //
						exit_flow__conveyor_belt__index = C.none,
						// to be calculated later //


						resource_type_allowed = C.any__payload,
						payload = C.none
					},

					new LET()
					{
						local_pos = new int[2]{0, 0},
						type_of_let = C.inlet,

						local_pos_of_tile_associated = new int[2]{-1, 0},
						state_of_tile = C.f__state,


						// to be calculated later //
						exit_flow__conveyor_belt__index = C.none,
						// to be calculated later //


						resource_type_allowed = C.any__payload,
						payload = C.none
					},


					new LET()
					{
						local_pos = new int[2]{0, +1},
						type_of_let = C.inlet,

						local_pos_of_tile_associated = new int[2]{-1, +1},
						state_of_tile = C.f__state,


						// to be calculated later //
						exit_flow__conveyor_belt__index = C.none,
						// to be calculated later //


						resource_type_allowed = C.any__payload,
						payload = C.none
					},


					new LET()
					{
						local_pos = new int[2]{0, 0},
						type_of_let = C.outlet,

						local_pos_of_tile_associated = new int[2]{+1, 0},
						state_of_tile = C.f__state,


						// to be calculated later //
						exit_flow__conveyor_belt__index = C.none,
						// to be calculated later //


						resource_type_allowed = C.any__payload,
						payload = C.none
					}

				};

			}

			else if (TYPE_OF_MACHINE == C.SPLITTER__machine)
			{
				#region BEFORE
				/*
				return new List<LET>()
				{
					new LET()
					{
						local_pos = new int[2]{0, 0},
						type_of_let = C.outlet,

						local_pos_of_tile_associated = new int[2]{0, -1},
						state_of_tile = C.r__state,


						// to be calculated later //
						exit_flow__conveyor_belt__index = C.none,
						// to be calculated later //


						resource_type_allowed = C.any__payload,
						payload = C.none
					},



					new LET()
					{
						local_pos = new int[2]{0, 0},
						type_of_let = C.outlet,

						local_pos_of_tile_associated = new int[2]{0, +1},
						state_of_tile = C.l__state,


						// to be calculated later //
						exit_flow__conveyor_belt__index = C.none,
						// to be calculated later //


						resource_type_allowed = C.any__payload,
						payload = C.none
					},

					new LET()
					{
						local_pos = new int[2]{0, 0},
						type_of_let = C.outlet,

						local_pos_of_tile_associated = new int[2]{+1, 0},
						state_of_tile = C.f__state,


						// to be calculated later //
						exit_flow__conveyor_belt__index = C.none,
						// to be calculated later //


						resource_type_allowed = C.any__payload,
						payload = C.none
					},


					new LET()
					{
						local_pos = new int[2]{0, 0},
						type_of_let = C.inlet,

						local_pos_of_tile_associated = new int[2]{-1, 0},
						state_of_tile = C.f__state,


						// to be calculated later //
						exit_flow__conveyor_belt__index = C.none,
						// to be calculated later //


						resource_type_allowed = C.any__payload,
						payload = C.none
					},

				}; 
				*/
				#endregion



				return new List<LET>()
				{
					new LET()
					{
						local_pos = new int[2]{0, -1},
						type_of_let = C.outlet,

						local_pos_of_tile_associated = new int[2]{+1, -1},
						state_of_tile = C.f__state,


						// to be calculated later //
						exit_flow__conveyor_belt__index = C.none,
						// to be calculated later //


						resource_type_allowed = C.any__payload,
						payload = C.none
					},



					new LET()
					{
						local_pos = new int[2]{0, 0},
						type_of_let = C.outlet,

						local_pos_of_tile_associated = new int[2]{+1, 0},
						state_of_tile = C.f__state,


						// to be calculated later //
						exit_flow__conveyor_belt__index = C.none,
						// to be calculated later //


						resource_type_allowed = C.any__payload,
						payload = C.none
					},

					new LET()
					{
						local_pos = new int[2]{0, +1},
						type_of_let = C.outlet,

						local_pos_of_tile_associated = new int[2]{+1, +1},
						state_of_tile = C.f__state,


						// to be calculated later //
						exit_flow__conveyor_belt__index = C.none,
						// to be calculated later //


						resource_type_allowed = C.any__payload,
						payload = C.none
					},


					new LET()
					{
						local_pos = new int[2]{0, 0},
						type_of_let = C.inlet,

						local_pos_of_tile_associated = new int[2]{-1, 0},
						state_of_tile = C.f__state,


						// to be calculated later //
						exit_flow__conveyor_belt__index = C.none,
						// to be calculated later //


						resource_type_allowed = C.any__payload,
						payload = C.none
					},

				};

			}

			else if (TYPE_OF_MACHINE == C.CONSUMER)
			{
				return new List<LET>()
				{
					new LET()
					{
						local_pos = new int[2]{0, 0},
						type_of_let = C.inlet,

						local_pos_of_tile_associated = new int[2]{-1, 0},
						state_of_tile = C.f__state,


						// to be calculated later //
						exit_flow__conveyor_belt__index = C.none,
						// to be calculated later //


						resource_type_allowed = C.any__payload,
						payload = C.none,
					}


				};



			}


			else
			{
				return new List<LET>();
			}
		}


		// possible ? //
		public bool MOVE(int[] global_pos)
		{

			for (int i0 = 0; i0 < LET_1D.Count; i0 += 1)
			{
				//
				int[] new_let_global_pos = new int[2]
				{
					global_pos[0] +  this.LET_1D[i0].local_pos[0],
					global_pos[1] +  this.LET_1D[i0].local_pos[1],
				};
				//


				int w = STORE.GRID[0].Length;
				int h = STORE.GRID.Length;
				//
				bool step_on_bound = ( new_let_global_pos[0] <= 0 || new_let_global_pos[0] >= w - 1 ||
									    new_let_global_pos[1] <= 0 || new_let_global_pos[1] >= h - 1 );

				if (step_on_bound)
				{
					//
					return false;
				}




				TILE tile = STORE.GRID[new_let_global_pos[1]][new_let_global_pos[0]];
				int index__in__machine_holder =
					STORE.GRID[this.global_pos[1]][this.global_pos[0]].TILE_INDEX_in_HOLDER;


				bool allowed_tiles = (tile.TILE_TYPE == C.EMPTY__tile) ||
									 (tile.TILE_TYPE == C.MACHINE__tile &&
									   tile.TILE_INDEX_in_HOLDER == index__in__machine_holder);

				//
				if (!allowed_tiles)
				{
					return false;
				}
				//
			}



			// perform translate //

			this.global_pos = global_pos;
			// perform translate //

			return true;
		}



		// possible ? //
		public bool ROTATE()
		{

			for(int i0 = 0; i0 < LET_1D.Count; i0 += 1)
			{
				//
				int[] new_let_global_pos = new int[2]
				{
					this.global_pos[0] - this.LET_1D[i0].local_pos[1],
					this.global_pos[1] + this.LET_1D[i0].local_pos[0],
				};
				//

				int w = STORE.GRID[0].Length;
				int h = STORE.GRID.Length;
				bool step_on_bound = (new_let_global_pos[0] <= 0 || new_let_global_pos[0] >= w - 1 || new_let_global_pos[1] <= 0 || new_let_global_pos[1] >= h - 1);

				if (step_on_bound)
				{
					//
					return false;
				}




				TILE tile = STORE.GRID[new_let_global_pos[1]][new_let_global_pos[0]];
				int index__in__machine_holder = 
					STORE.GRID[this.global_pos[1]][this.global_pos[0]].TILE_INDEX_in_HOLDER;



				


				bool allowed_tiles = ( tile.TILE_TYPE == C.EMPTY__tile ) || 
									 ( tile.TILE_TYPE == C.MACHINE__tile && 
									   tile.TILE_INDEX_in_HOLDER == index__in__machine_holder );

				//
				if (!allowed_tiles)
				{
					return false;
				}
				//
			}



			// perform rotation //
			for (int i0 = 0; i0 < LET_1D.Count; i0 += 1)
			{
				//
				int[] new__local_pos = new int[2]
				{
					-this.LET_1D[i0].local_pos[1],
					+this.LET_1D[i0].local_pos[0],
				};
				//



				//
				int[] new__conveyor_belt_associated_local_pos = new int[2]
				{
					-this.LET_1D[i0].local_pos_of_tile_associated[1],
					+this.LET_1D[i0].local_pos_of_tile_associated[0],
				};
				//

				//
				int new__state_of_tile = (this.LET_1D[i0].state_of_tile + 1) % 4;



				LET_1D[i0].local_pos = new__local_pos;
				LET_1D[i0].local_pos_of_tile_associated = new__conveyor_belt_associated_local_pos;
				LET_1D[i0].state_of_tile = new__state_of_tile;

				LET_1D[i0].exit_flow__conveyor_belt__index = C.none;
			}
			// perform rotation //

			this.rotation = (this.rotation + 1) % 4;

			return true;

		}


		public void REMOVE()
		{
				
		}

		// ONLY GET from STORE, NO MODIFICATION TO STORE IS DONE //


		// inlet_index__to__explore method //
		public int inlet_index__to__explore = 0;
		// inlet_index__to__explore method //


		// outlet_index__to__explore method //
		public int outlet_index__to__explore = 0;
		// outlet_index__to__explore method //



		public int[] resources_count;
		public int[] consumes_count;


		public void TAKE__PAYLOAD_FROM_INLET___and___ADD__PAYLOAD__TO_PATH()
		{

			// PRODUCER //
			if (this.TYPE_OF_MACHINE == C.PRODUCER)
			{

				if ((int)Time.time % 5 != 0)
				{
					return;
				}

				LET outlet = this.LET_1D[0];

				if (outlet.exit_flow__conveyor_belt__index != C.none)
				{

					CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[outlet.exit_flow__conveyor_belt__index];

					PATH path = STORE.PATHS[belt.PATH_index];

					//
					if (path.Add_PayLoad_from__machine(C.A__payload))
					{

						// create payload, which shall be same index as PayLoad insterted just now //
						_RENDER_.CREATE__payload(resource_type: C.A__payload);
						// create payload, which shall be same index as PayLoad insterted just now //

						// payload has been added to path
					}
				}

			}
			// PRODUCER //

			// CONSUMER //
			else if (this.TYPE_OF_MACHINE == C.CONSUMER)
			{
				if ((int)Time.time % 3 != 0)
				{
					return;
				}

				LET inlet = this.LET_1D[0];


				if (inlet.payload != C.none)
				{
					resources_count[inlet.payload] += 1;
					inlet.payload = C.none;
				}

			}
			// CONSUMER //

			// COMBINER //
			else if (this.TYPE_OF_MACHINE == C.COMBINER__machine)
			{
				#region METHID - 1
				// payloads from inlet to machine

				#region inlet__explore__METHOD

				LET inlet = this.LET_1D[inlet_index__to__explore];

				#region explore inlet has no payload case
				if (this.LET_1D[inlet_index__to__explore].payload == C.none__payload)
				{
					for (int i0 = inlet_index__to__explore + 1; i0 <= inlet_index__to__explore + 2; i0 += 1)
					{
						if (this.LET_1D[(i0 % 3)].payload != C.none__payload)
						{
							inlet_index__to__explore = (i0 % 3);
						}
					}


				}
				#endregion





				// empty the payload in inlet and Add it to the path at outlet //
				if (inlet.payload != C.none__payload)
				{


					LET outlet = this.LET_1D[3];
					if (outlet.exit_flow__conveyor_belt__index != C.none)
					{
						//
						CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[outlet.exit_flow__conveyor_belt__index];

						PATH path = STORE.PATHS[belt.PATH_index];
						if (path.Add_PayLoad_from__machine(inlet.payload))
						{
							// create payload, which shall be same index as PayLoad insterted just now //
							_RENDER_.CREATE__payload(resource_type: inlet.payload);
							// create payload, which shall be same index as PayLoad insterted just now //

							// empty the inlet //
							inlet.payload = C.none__payload;
							// empty the inlet //



							// next inlet to explore //
							for (int i0 = inlet_index__to__explore + 1; i0 <= inlet_index__to__explore + 2; i0 += 1)
							{
								if (this.LET_1D[i0 % 3].payload != C.none__payload)
								{
									inlet_index__to__explore = (i0 % 3);
									break;
								}
							}
							// next inlet to explore //



						}
					}

				}





				// empty the payload in inlet and Add it to the path at outlet //
				#endregion




				#endregion



				#region METHOD - 0
				/*
				for (int i0 = 0; i0 <= 2; i0 += 1)
				{

					LET inlet = this.LET_1D[i0];
					if (inlet.payload != C.none__payload)
					{



						// empty payload and add to path if possible
						LET outlet = LET_1D[3];
						if (outlet.exit_flow__conveyor_belt__index != C.none)
						{

							CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[outlet.exit_flow__conveyor_belt__index];
							PATH path = STORE.PATHS[belt.PATH_index];

							if (path.Add_PayLoad_from__machine(resource_type: inlet.payload))
							{
								_RENDER_.CREATE__payload(resource_type: inlet.payload);
								inlet.payload = C.none__payload;

							}
							//
						}

					}
					//
				} 
				*/
				#endregion


			}
			// COMBINER //

			// SPLITTER //
			else if (this.TYPE_OF_MACHINE == C.SPLITTER__machine)
			{
				#region METHID - 0
				// payloads from inlet to machine
				/*
				
				#region outlet__explore__METHOD

				LET inlet = this.LET_1D[3];



				// empty the payload in inlet and Add it to the path at outlet //
				if (inlet.payload != C.none__payload)
				{

					LET outlet = this.LET_1D[outlet_index__to__explore];
					if (outlet.exit_flow__conveyor_belt__index != C.none)
					{
						//
						CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[outlet.exit_flow__conveyor_belt__index];

						PATH path = STORE.PATHS[belt.PATH_index];
						if (path.Add_PayLoad_from__machine(inlet.payload))
						{
							// create payload, which shall be same index as PayLoad insterted just now //
							_RENDER_.CREATE__payload(resource_type: inlet.payload);
							// create payload, which shall be same index as PayLoad insterted just now //

							// empty the inlet //
							inlet.payload = C.none__payload;
							// empty the inlet //




							// next outlet to explore //
							outlet_index__to__explore = (outlet_index__to__explore + 1) % 3;
							// next outlet to explore //

						}

					}

				}











				// empty the payload in inlet and Add it to the path at outlet //
				#endregion



				*/
				#endregion


				#region METHID - 1
				// payloads from inlet to machine

				#region outlet__explore__METHOD

				// empty the payload in inlet and Add it to the path at outlet //
				LET inlet = this.LET_1D[3];




				for (int i0 = outlet_index__to__explore + 1; i0 <= outlet_index__to__explore + 3; i0 += 1)
				{
					if (inlet.payload != C.none__payload)
					{


						LET outlet = this.LET_1D[(i0 % 3)];
						if (outlet.exit_flow__conveyor_belt__index != C.none)
						{
							//
							CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[outlet.exit_flow__conveyor_belt__index];

							PATH path = STORE.PATHS[belt.PATH_index];
							if (path.Add_PayLoad_from__machine(inlet.payload))
							{
								// create payload, which shall be same index as PayLoad insterted just now //
								_RENDER_.CREATE__payload(resource_type: inlet.payload);
								// create payload, which shall be same index as PayLoad insterted just now //

								// empty the inlet //
								inlet.payload = C.none__payload;
								// empty the inlet //




								// next outlet to explore //
								outlet_index__to__explore = i0;
								break;
								// next outlet to explore //

							}

						}

					}



				}














				// empty the payload in inlet and Add it to the path at outlet //
				#endregion




				#endregion

			}
			// SPLITTER  //


		}





	}

	public class LET
	{
		public int[] local_pos;                              // v2 local
		public int type_of_let;                              // inlet , outlet , block 


		public int[] local_pos_of_tile_associated;           // v2 local
		public int state_of_tile;                            // [absolute] r, f, l, b
		public int exit_flow__conveyor_belt__index;  // index , none


		public int resource_type_allowed;                    // resource_type , anything
		public int payload;                                  // resource_type , none
	}





	#region C CONSTANT / TILE_CONFIGURATION

	public static class C
	{

		// TILE_TYPE
		public static int CONVEYOR_BELT__tile = 0;
		public static int EMPTY__tile = 1;
		public static int MACHINE__tile = 2;
		public static int NONE__tile = -1;


		// state_of_tile
		public static int f__state = 0;
		public static int l__state = 1;
		public static int b__state = 2;
		public static int r__state = 3;
		public static int none__state = -1;

		// dir 
		// [absolute] r , f , l , b //
		public static int[][] DIRS = new int[4][]
		{
			new int[2] { +1 ,  0 },
			new int[2] {  0 , +1 },
			new int[2] { -1 ,  0 },
			new int[2] {  0 , -1 },
		};
		// [absolute] r , f , l , b //



		//[relative to state of tile] linkage_type
		public static int r_to_f__linkage = 0;
		public static int l_to_f__linkage = 1;
		public static int b_to_f__linkage = 2;
		public static int none__linkage = -1;


		// flow_type
		public static int CONVEYOR_BELT__flow = 0;
		public static int MACHINE__flow = 1;
		public static int NONE__flow = -1;


		// LET
		public static int inlet = 0;
		public static int outlet = 1;
		public static int block_let = -1;


		// resource_type
		public static int A__payload = 0;
		public static int any__payload = 100;
		public static int none__payload = -1;
		// public static int WOOD__resource = 3;
		public static int TOTAL_resources_count = 1;





		// TYPE_OF_MACHINE
		public static int PRODUCER = 0;
		public static int CONVERTER__machine = 1;
		public static int COMBINER__machine = 2;
		public static int SPLITTER__machine = 3;
		public static int WOOD_HAY__machine = 4;
		public static int OIL_BARREL__MACHINE = 5;
		public static int FIRE_EXTRACTOR__machine = 6;
		public static int BARN__machine = 7;
		public static int PRODUCER_oil__machine = 8;

		public static int CONSUMER = 9;
		public static int CONSUMER_oil_barrel__machine = 10;
		public static int none__machine = -1;


		// path_type
		public static int linear_path = 0;
		public static int circular_path = 1;



		// index
		public static int none = -1;








		// INPUT //
		public static int CONVEYOR_BELT__draw = 0;
		public static int MACHINE__draw = 1;

		// INPUT //





		// animate //
		public static float dt = Time.deltaTime;
		public static float v = 0.5f;

		// animate //



	}
	#endregion









	///// STUFF /////




	#region Z
	//
	public static class Z
	{
		#region lerp
		public static Vector3 lerp(Vector3 a, Vector3 b, float t)
		{
			Vector3 n = b - a;
			return a + n * t;
		}

		public static float lerp(float a, float b, float t)
		{
			float n = b - a;
			return a + n * t;
		}
		#endregion

		#region bezier
		public static Vector2 bezier_position(Vector2[] P, float t)
		{
			Vector2 l_0 = Z.lerp(P[0], P[1], t);
			Vector2 l_1 = Z.lerp(P[1], P[2], t);
			Vector2 l_2 = Z.lerp(P[2], P[3], t);

			Vector2 q_0 = Z.lerp(l_0, l_1, t);
			Vector2 q_1 = Z.lerp(l_1, l_2, t);

			return Z.lerp(q_0, q_1, t);
		}

		public static Vector2 bezier_velocity(Vector2[] P, float t)
		{

			/*
			return 1 * (1 - t) * (1 - t) * (1 - t) * P[0] +
				 	3 * (1 - t) * (1 - t) * t * P[1] +
				 	3 * (1 - t) * t * t * P[2] +
																t * t * t * P[3];

			*/

			return Z.bezier_position(P, t + 1f / 100) - Z.bezier_position(P, t - 1f / 100);

		}
		#endregion

	}
	//
	#endregion








	// INPUT ---- COMMAND ---- STORE
	#region COMMAND
	public static class COMMAND
	{

		#region COMMAND


		// ANY__TILE //
		public static void COMMAND_ROTATE_ANY__TILE(int[] global_pos)
		{
			TILE tile = STORE.GRID[global_pos[1]][global_pos[0]];

			if (tile.TILE_TYPE == C.CONVEYOR_BELT__tile) { COMMAND_ROTATE__CONVEYOR_BELT(global_pos); }
			if (tile.TILE_TYPE == C.MACHINE__tile)		 { COMMAND_ROTATE__MACHINE(global_pos); }

		}

		public static void COMMAND_REMOVE_ANY__TILE(int[] global_pos)
		{
			TILE tile = STORE.GRID[global_pos[1]][global_pos[0]];

			if (tile.TILE_TYPE == C.CONVEYOR_BELT__tile) { COMMAND_REMOVE__CONVEYOR_BELT(global_pos); }
			if (tile.TILE_TYPE == C.MACHINE__tile) { COMMAND_REMOVE__MACHINE(global_pos); }
		}
		// ANY__TILE //






		public static void COMMAND_CREATE__CONVEYOR_BELT(int[] global_pos, int state_of_tile = 0)
		{
			TILE tile = STORE.GRID[global_pos[1]][global_pos[0]];
			//
			if (tile.TILE_TYPE != C.EMPTY__tile)
			{
				return;
			}


			CONVEYOR_BELT belt = CONVEYOR_BELT.CREATE(global_pos, state_of_tile);


			// update in L<> CONVEYOR_BELT
			STORE.CONVEYOR_BELT__1D.Add(belt);
			// update in TILE[][] tile_type , tile_index_in_L<>

			tile.TILE_TYPE = C.CONVEYOR_BELT__tile;
			tile.TILE_INDEX_in_HOLDER = STORE.CONVEYOR_BELT__1D.Count - 1;
			// 

			// CALCULATION of belt __linkage __enter_flow __exit_flow
			// CALCULATION PATH

			// STORE.UPDATE__CONVEYOR_BELT__CONFIGURATIONS__and__PATHS_CALCULATION();
			ORDER__OF__CALCULATION.PERFORM();






			// _RENDER_ //
			_RENDER_.CREATE__conveyor_belt();


			// update all --conveyor belt states prefab , --payload position
			ORDER__OF__CALCULATION.PERFORM_RENDER();

			// _RENDER_ //

		}

		public static void COMMAND_ROTATE__CONVEYOR_BELT(int[] global_pos, int state_of_tile = -1)
		{

			// ROTATE //
			TILE tile = STORE.GRID[global_pos[1]][global_pos[0]];
			if (tile.TILE_TYPE != C.CONVEYOR_BELT__tile)
			{
				return;
			}



			CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[tile.TILE_INDEX_in_HOLDER];

			if (state_of_tile == C.none)
			{ belt.state_of_tile = (belt.state_of_tile + 1) % 4; }
			else
			{ belt.state_of_tile = state_of_tile; }
			// ROTATE //



			// CALCULATE //
			//STORE.UPDATE__CONVEYOR_BELT__CONFIGURATIONS__and__PATHS_CALCULATION();
			ORDER__OF__CALCULATION.PERFORM();
			
			//
			Debug.Log(STORE.CONVEYOR_BELT__1D[0].bezier_curve[0]);
			// CALCULATE //
			//




			// _RENDER_ //

			for (int i0 = 0; i0 < STORE.CONVEYOR_BELT__1D.Count; i0 += 1)
			{
				_RENDER_.UPDATE__conveyor_belt__TRANSFORM(STORE.CONVEYOR_BELT__1D[i0]);
				// _RENDER_.UPDATE__conveyor_belt__payload(STORE.CONVEYOR_BELT__1D[i0], t: 0.5f);
			}


			for(int i0 = 0; i0 < STORE.PAYLOADS.Count; i0 += 1)
			{
				// will do
				_RENDER_.UPDATE__payload__TRANSFORM(STORE.PAYLOADS[i0]);
			}
			// _RENDER_ //


		}

		// TODO --DONE
		public static void COMMAND_REMOVE__CONVEYOR_BELT(int[] global_pos)
		{

			// REMOVE //
			TILE tile = STORE.GRID[global_pos[1]][global_pos[0]];
			if (tile.TILE_TYPE != C.CONVEYOR_BELT__tile)
				return;

			CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[tile.TILE_INDEX_in_HOLDER];



			
			// PayLoad //
			PATH path = STORE.PATHS[belt.PATH_index];

			for (int i0 = path.payloads.Count - 1; i0 >= 0; i0 -= 1)
			{
				PayLoad payload = path.payloads[i0];
				if (payload.belt == belt)
				{
					int index_of_payload = STORE.PAYLOADS.IndexOf(payload);

					STORE.PAYLOADS.Remove(payload);
					// path.payloads.Remove(payload);

					_RENDER_.OBJ__payload__1D[index_of_payload].SetActive(false);
					_RENDER_.OBJ__payload__1D[index_of_payload].transform.parent = _RENDER_.Deactivated;
					_RENDER_.OBJ__payload__1D.RemoveAt(index_of_payload);
				}

			}
			// PayLoad //








			STORE.CONVEYOR_BELT__1D.Remove(belt);


			int index_of_tile = STORE.GRID[global_pos[1]][global_pos[0]].TILE_INDEX_in_HOLDER;

			// make it empty //
			STORE.GRID[global_pos[1]][global_pos[0]].TILE_TYPE = C.EMPTY__tile;
			STORE.GRID[global_pos[1]][global_pos[0]].TILE_INDEX_in_HOLDER = C.NONE__tile;

			// make it empty //





			// CALCULATE //
			//STORE.UPDATE__CONVEYOR_BELT__CONFIGURATIONS__and__PATHS_CALCULATION();
			ORDER__OF__CALCULATION.PERFORM(removed__tile_type : C.CONVEYOR_BELT__tile);
			// CALCULATE //
			//





			// _RENDER_ //


			_RENDER_.OBJ__conveyor_belt__1D[index_of_tile].SetActive(false);
			_RENDER_.OBJ__conveyor_belt__1D[index_of_tile].transform.parent = _RENDER_.Deactivated;
			_RENDER_.OBJ__conveyor_belt__1D.RemoveAt(index_of_tile);


			for (int i0 = 0; i0 < STORE.CONVEYOR_BELT__1D.Count; i0 += 1)
			{
				_RENDER_.UPDATE__conveyor_belt__TRANSFORM(STORE.CONVEYOR_BELT__1D[i0]);
			}

			// _RENDER_ //



		}



		public static void COMMAND_CREATE__MACHINE(int[] global_pos, int TYPE_OF_MACHINE = 2)
		{
			TILE tile = STORE.GRID[global_pos[1]][global_pos[0]];
			//
			if (tile.TILE_TYPE != C.EMPTY__tile)
			{
				return;
			}
			

			MACHINE machine = MACHINE.CREATE(global_pos, TYPE_OF_MACHINE);
			if(!machine.MOVE(global_pos))
			{
				return;
			}




			// update in L<> MACHINE
			STORE.MACHINE__1D.Add(machine);

			// update in TILE[][] tile_type , tile_index_in_L<>



			for (int i0 = 0; i0 < machine.LET_1D.Count; i0 += 1)
			{
				int[] global_let_pos = new int[2]
				{
					machine.global_pos[0] + machine.LET_1D[i0].local_pos[0],
					machine.global_pos[1] + machine.LET_1D[i0].local_pos[1],
				};

				TILE let_tile = STORE.GRID[global_let_pos[1]][global_let_pos[0]]; 
				let_tile.TILE_TYPE = C.MACHINE__tile;
				let_tile.TILE_INDEX_in_HOLDER = STORE.MACHINE__1D.Count - 1;
				//
			}




			// CALCULATION //
			ORDER__OF__CALCULATION.PERFORM();
			// CALCULATION //




			// _RENDER_CALCULATION_ //
			_RENDER_.CREATE__machine(TYPE_OF_MACHINE);


			// update all --conveyor belt states prefab , --payload position
			ORDER__OF__CALCULATION.PERFORM_RENDER();

			// _RENDER_CALCULATION_ //





		}



		public static void COMMAND_MOVE__MACHINE(MACHINE machine , int[] global_pos)
		{

			int[][] prev_let_global_pos__1D = new int[machine.LET_1D.Count][];
			//
			for (int i0 = 0; i0 < machine.LET_1D.Count; i0 += 1)
			{
				//
				prev_let_global_pos__1D[i0] = new int[2]
				{
					machine.global_pos[0] + machine.LET_1D[i0].local_pos[0],
					machine.global_pos[1] + machine.LET_1D[i0].local_pos[1],
				};
				//
			}


			if (!machine.MOVE(global_pos))
			{
				return;
			}



			for (int i0 = 0; i0 < prev_let_global_pos__1D.Length; i0 += 1)
			{
				TILE prev__let_tile = STORE.GRID[prev_let_global_pos__1D[i0][1]][prev_let_global_pos__1D[i0][0]];
				prev__let_tile.TILE_TYPE = C.EMPTY__tile;
				prev__let_tile.TILE_INDEX_in_HOLDER = C.none;
			}


			int machine_index_in_HOLDER = STORE.MACHINE__1D.IndexOf(machine);
			for (int i0 = 0; i0 < machine.LET_1D.Count; i0 += 1)
			{
				LET let = machine.LET_1D[i0];
				//
				int[] global_let_pos = new int[2]
				{
					machine.global_pos[0] + let.local_pos[0],
					machine.global_pos[1] + let.local_pos[1],
				};


				TILE curr_let_tile = STORE.GRID[global_let_pos[1]][global_let_pos[0]];
				curr_let_tile.TILE_TYPE = C.MACHINE__tile;
				curr_let_tile.TILE_INDEX_in_HOLDER = machine_index_in_HOLDER;
				//
			}






			// ROTATE //



			// CALCULATE //
			//STORE.UPDATE__CONVEYOR_BELT__CONFIGURATIONS__and__PATHS_CALCULATION();
			ORDER__OF__CALCULATION.PERFORM();




			// _RENDER_ //

			for (int i0 = 0; i0 < STORE.MACHINE__1D.Count; i0 += 1)
			{
				// will do
				_RENDER_.UPDATE__machine__TRANSFORM(STORE.MACHINE__1D[i0]);
			}

			for (int i0 = 0; i0 < STORE.CONVEYOR_BELT__1D.Count; i0 += 1)
			{
				// will do
				_RENDER_.UPDATE__conveyor_belt__TRANSFORM(STORE.CONVEYOR_BELT__1D[i0]);
			}
			// _RENDER_ //



		}


		public static void COMMAND_ROTATE__MACHINE(int[] global_pos)
		{
			// ROTATE //
			TILE tile = STORE.GRID[global_pos[1]][global_pos[0]];
			if (tile.TILE_TYPE != C.MACHINE__tile)
			{
				return;
			}


			MACHINE machine = STORE.MACHINE__1D[tile.TILE_INDEX_in_HOLDER];

			int[][] prev_let_global_pos__1D = new int[machine.LET_1D.Count][];
			//
			for(int i0 = 0; i0 < machine.LET_1D.Count; i0 += 1)
			{
				//
				prev_let_global_pos__1D[i0] = new int[2]
				{
					machine.global_pos[0] + machine.LET_1D[i0].local_pos[0],
					machine.global_pos[1] + machine.LET_1D[i0].local_pos[1],
				};
				//
			}




			if(!machine.ROTATE())
			{
				return;
			}
			


			for(int i0 = 0; i0 < prev_let_global_pos__1D.Length; i0 += 1)
			{
				TILE prev__let_tile = STORE.GRID[prev_let_global_pos__1D[i0][1]][prev_let_global_pos__1D[i0][0]];
				prev__let_tile.TILE_TYPE = C.EMPTY__tile;
				prev__let_tile.TILE_INDEX_in_HOLDER = C.none;
			}


			int machine_index_in_HOLDER = STORE.MACHINE__1D.IndexOf(machine);
			for (int i0 = 0; i0 < machine.LET_1D.Count; i0 += 1)
			{
				LET let = machine.LET_1D[i0];
				//
				int[] global_let_pos = new int[2]
				{
					machine.global_pos[0] + let.local_pos[0],
					machine.global_pos[1] + let.local_pos[1],
				};


				TILE curr_let_tile = STORE.GRID[global_let_pos[1]][global_let_pos[0]];
				curr_let_tile.TILE_TYPE = C.MACHINE__tile;
				curr_let_tile.TILE_INDEX_in_HOLDER = machine_index_in_HOLDER;
				//
			}






			// ROTATE //



			// CALCULATE //
			//STORE.UPDATE__CONVEYOR_BELT__CONFIGURATIONS__and__PATHS_CALCULATION();
			ORDER__OF__CALCULATION.PERFORM();




			// _RENDER_ //

			for (int i0 = 0; i0 < STORE.MACHINE__1D.Count; i0 += 1)
			{
				// will do
				_RENDER_.UPDATE__machine__TRANSFORM(STORE.MACHINE__1D[i0]);
			}

			for (int i0 = 0; i0 < STORE.CONVEYOR_BELT__1D.Count; i0 += 1)
			{
				// will do
				_RENDER_.UPDATE__conveyor_belt__TRANSFORM(STORE.CONVEYOR_BELT__1D[i0]);
			}
			// _RENDER_ //


		}

		public static void COMMAND_REMOVE__MACHINE(int[] global_pos)
		{

			// REMOVE //
			TILE tile = STORE.GRID[global_pos[1]][global_pos[0]];
			if (tile.TILE_TYPE != C.MACHINE__tile)
				return;


			MACHINE machine = STORE.MACHINE__1D[tile.TILE_INDEX_in_HOLDER];


			STORE.MACHINE__1D.Remove(machine);


			int index_of_tile = STORE.GRID[global_pos[1]][global_pos[0]].TILE_INDEX_in_HOLDER;



			// make it empty //

			for (int i0 = 0; i0 < machine.LET_1D.Count; i0 += 1)
			{
				int[] global_let_pos = new int[2]
				{
					machine.global_pos[0] + machine.LET_1D[i0].local_pos[0],
					machine.global_pos[1] + machine.LET_1D[i0].local_pos[1],
				};

				TILE let_tile = STORE.GRID[global_let_pos[1]][global_let_pos[0]];

				let_tile.TILE_TYPE = C.EMPTY__tile;
				let_tile.TILE_INDEX_in_HOLDER = C.NONE__tile;
			}

			// make it empty //





			// CALCULATE //
			//STORE.UPDATE__CONVEYOR_BELT__CONFIGURATIONS__and__PATHS_CALCULATION();
			ORDER__OF__CALCULATION.PERFORM(removed__tile_type: C.MACHINE__tile);
			// CALCULATE //
			//





			// _RENDER_ //


			_RENDER_.OBJ__machine__1D[index_of_tile].SetActive(false);
			_RENDER_.OBJ__machine__1D[index_of_tile].transform.parent = _RENDER_.Deactivated;
			_RENDER_.OBJ__machine__1D.RemoveAt(index_of_tile);


			for (int i0 = 0; i0 < STORE.MACHINE__1D.Count; i0 += 1)
			{
				_RENDER_.UPDATE__machine__TRANSFORM(STORE.MACHINE__1D[i0]);
			}

			// _RENDER_ //

			// call ORDER_OF_CALCULATION.PERFORM_RENDER();



		}

		#endregion

	}
	#endregion


	// COMMAND  ----  _INPUT_
	#region _INPUT_
	public static class _INPUT_
	{

		#region EVENT --without coroutine
		public static void EVENT(int[] dimension)
		{
			int w = dimension[0],
				h = dimension[1];

			int[] pos2D = new int[2]
			{
				round(_INPUT_.pos2D.x),
				round(_INPUT_.pos2D.z),
			};


			if (pos2D[0] <= 0 || pos2D[0] >= w - 1 || pos2D[1] <= 0 || pos2D[1] >= h - 1)
			{
				return;
			}



			if (Input.GetMouseButtonDown(0))
			{
				//
				if (Input.GetKey(KeyCode.R))
				{
					COMMAND.COMMAND_ROTATE_ANY__TILE(pos2D);

				}
				//
				// else if (Input.GetKey(KeyCode.P)) { COMMAND.COMMAND_PAYLOAD__CONVEYOR_BELT(pos2D, C.rock__resource); }
				// else if (Input.GetKey(KeyCode.W)) { COMMAND.COMMAND_PAYLOAD__CONVEYOR_BELT(pos2D, C.wood__resource); }


				//
				else if (Input.GetKey(KeyCode.X))
				{
					COMMAND.COMMAND_REMOVE_ANY__TILE(pos2D);
					// COMMAND.COMMAND_REMOVE__CONVEYOR_BELT(pos2D);
				}

				else if (Input.GetKey(KeyCode.M))
				{
					COMMAND.COMMAND_CREATE__MACHINE(pos2D, TYPE_OF_MACHINE: C.COMBINER__machine);
				}

				else if (Input.GetKey(KeyCode.N))
				{
					COMMAND.COMMAND_CREATE__MACHINE(pos2D, TYPE_OF_MACHINE: C.SPLITTER__machine);
				}


				//
				else
				{
					COMMAND.COMMAND_CREATE__CONVEYOR_BELT(pos2D, state_of_tile: C.f__state);
				}
				//
			}




		}

		#endregion


		// TODO : instead of KeyCode use EVENT_DRAW_MODE
		public static int EVENT_DRAW_MODE = C.CONVEYOR_BELT__draw;


		public static IEnumerator COROUTINE_EVENT(int[] dimension)
		{
			int w = dimension[0],
				h = dimension[1];






			while (true)
			{
				int[] pos2D = new int[2]
				{
					round(_INPUT_.pos2D.x),
					round(_INPUT_.pos2D.z),
				};
				//
				if (pos2D[0] <= 0 || pos2D[0] >= w - 1 || pos2D[1] <= 0 || pos2D[1] >= h - 1)
				{
					yield return null;
					continue;
				}
				//
				_RENDER_.PREFAB__pointer_cube.transform.position = new Vector3(pos2D[0], 0.5f, pos2D[1]);




				if (Input.GetKeyDown(KeyCode.R)) { COMMAND.COMMAND_ROTATE_ANY__TILE(pos2D); }
				else if (Input.GetKeyDown(KeyCode.X)) { COMMAND.COMMAND_REMOVE_ANY__TILE(pos2D); }
				else if (Input.GetKeyDown(KeyCode.M)) { COMMAND.COMMAND_CREATE__MACHINE(pos2D, TYPE_OF_MACHINE: C.COMBINER__machine); }
				else if (Input.GetKeyDown(KeyCode.N)) { COMMAND.COMMAND_CREATE__MACHINE(pos2D, TYPE_OF_MACHINE: C.SPLITTER__machine); }
				else if (Input.GetKeyDown(KeyCode.P)) { COMMAND.COMMAND_CREATE__MACHINE(pos2D, TYPE_OF_MACHINE: C.PRODUCER); }
				else if (Input.GetKeyDown(KeyCode.C)) { COMMAND.COMMAND_CREATE__MACHINE(pos2D, TYPE_OF_MACHINE: C.CONSUMER); }



				if (Input.GetMouseButton(0))
				{

					// if tile is empty
					TILE tile = STORE.GRID[pos2D[1]][pos2D[0]];
					if (tile.TILE_TYPE == C.EMPTY__tile)
					{

						// if conveyor_belt mode is selected()
						if (_INPUT_.EVENT_DRAW_MODE == C.CONVEYOR_BELT__draw)
						{


							List<int[]> P = new List<int[]>();
							List<CONVEYOR_BELT> belts = new List<CONVEYOR_BELT>();
							//
							while (true)
							{

								pos2D = new int[2]
								{
									round(_INPUT_.pos2D.x),
									round(_INPUT_.pos2D.z),
								};

								_RENDER_.PREFAB__pointer_cube.transform.position = new Vector3(pos2D[0], 0.5f, pos2D[1]);


								if (!Input.GetMouseButton(0))
								{


									if (P.Count == 1)
									{
										COMMAND.COMMAND_CREATE__CONVEYOR_BELT(P[0], state_of_tile: C.f__state);
									}
									else if (P.Count > 1)
									{

										for (int i0 = 0; i0 <= P.Count - 2; i0 += 1)
										{


											int state_of_tile = (((P[i0 + 1][0] - P[i0][0]) == 1) && ((P[i0 + 1][1] - P[i0][1]) == 0)) ? C.f__state :
																(((P[i0 + 1][0] - P[i0][0]) == 0) && ((P[i0 + 1][1] - P[i0][1]) == 1)) ? C.l__state :
																(((P[i0 + 1][0] - P[i0][0]) == -1) && ((P[i0 + 1][1] - P[i0][1]) == 0)) ? C.b__state :
																(((P[i0 + 1][0] - P[i0][0]) == 0) && ((P[i0 + 1][1] - P[i0][1]) == -1)) ? C.r__state : C.f__state;


											COMMAND.COMMAND_CREATE__CONVEYOR_BELT(P[i0], state_of_tile);





										}
										//
									}


									Debug.Log("points : " + P.Count);
									yield return null;
									break;
								}

								if (pos2D[0] <= 0 || pos2D[0] >= w - 1 || pos2D[1] <= 0 || pos2D[1] >= h - 1)
								{
									yield return null;
									continue;
								}


								//
								if (P.Count == 0)
								{
									P.Add(pos2D);
								}
								else if (P.Count > 0)
								{
									if (!(pos2D[0] == P[P.Count - 1][0] &&
											pos2D[1] == P[P.Count - 1][1]))
									{
										Debug.Log("added 1 point");
										P.Add(pos2D);
									}
								}
								//









								yield return null;
							}
						}

					}





					// if tile is machine
					else if (tile.TILE_TYPE == C.MACHINE__tile)
					{
						MACHINE machine = STORE.MACHINE__1D[tile.TILE_INDEX_in_HOLDER];



						int[] offset = new int[2]
						{
							machine.global_pos[0] - pos2D[0],
							machine.global_pos[1] - pos2D[1],
						};


						while (true)
						{

							pos2D = new int[2]
							{
								round(_INPUT_.pos2D.x),
								round(_INPUT_.pos2D.z),
							};
							//
							_RENDER_.PREFAB__pointer_cube.transform.position = new Vector3(pos2D[0], 0.5f, pos2D[1]);




							int[] global_pos = new int[]
							{
								pos2D[0] + offset[0],
								pos2D[1] + offset[1],
							};


							//
							COMMAND.COMMAND_MOVE__MACHINE(machine, global_pos);


							if (!Input.GetMouseButton(0))
							{
								break;
							}


							yield return null;
						}
					}





				}





				yield return null;
			}







		}



		public static Camera cam;

		#region pos2D
		static Vector3 pos2D
		{
			get
			{
				Ray ray = cam.ScreenPointToRay(Input.mousePosition);

				Vector3 a = ray.origin,
						n = ray.direction;

				Vector3 o = Vector3.zero,
						up = Vector3.up;

				// ((a + L * n) - o).up = 0
				float L = -Z.dot(a - o, up) / Z.dot(n, up);

				return a + L * n;
			}

		}
		#endregion



		#region Z
		public static class Z
		{
			#region dot
			//
			public static float dot(Vector3 a, Vector3 b)
			{
				return a.x * b.x + a.y * b.y + a.z * b.z;
			}
			//
			#endregion

		}
		#endregion



		#region round

		public static int round(float x)
		{
			int x_I = (int)x;
			float fraction = x - x_I;

			if (x < 0f)
			{
				if (fraction <= -0.5f) return x_I - 1;
			}
			else if (x > 0f)
			{
				if (fraction >= 0.5f) return x_I + 1;
			}

			return x_I;
		}

		#endregion




	}

	#endregion



	// _RENDER_ ---- STORE , DRAW

	#region _RENDER_
	//
	public static class _RENDER_
	{
		public static void RENDER__DRAW_TILES(TILE[][] GRID , List<PayLoad> PAYLOADS)
		{
			Vector3 DRAW_OFFSET = Vector3.up * -5;



			int y_L = GRID[0].Length,
				x_L = GRID.Length;

			for (int y = 0; y < y_L; y += 1)
			{
				for (int x = 0; x < x_L; x += 1)
				{
					TILE tile = GRID[y][x];


					// EMPTY__tile //
					if (tile.TILE_TYPE == C.EMPTY__tile)
					{
						DRAW.col = _RENDER_.GRAY(0.5f);

						DRAW.QUAD(pos: V2(x, y) + DRAW_OFFSET);
						DRAW.DIR
						(
							pos: V2(x, y) + DRAW_OFFSET,
							state_of_tile: C.none__state
						);
					}

					// CONVEYOR_BELT__tile //
					else if (tile.TILE_TYPE == C.CONVEYOR_BELT__tile)
					{
						//
						CONVEYOR_BELT belt = STORE.CONVEYOR_BELT__1D[tile.TILE_INDEX_in_HOLDER];

						DRAW.col = _RENDER_.GRAY(0.8f);
						DRAW.QUAD(pos: V2(x, y) + DRAW_OFFSET);
						DRAW.DIR
						(
							pos: V2(x, y)  + DRAW_OFFSET,
							state_of_tile: belt.state_of_tile
						);


						/*
						if (belt.payload != C.none__payload)
						{
							//
							DRAW.col = (belt.payload == C.rock__resource) ?
								Color.HSVToRGB(0.66f, 0.5f, 0.75f) :
								Color.HSVToRGB(0.1f, 0.5f, 0.50f);


							DRAW.QUAD(pos: V2(x, y), scale: 0.15f);
						}
						*/

					}


				}
			}



			for (int i0 = 0; i0 < PAYLOADS.Count; i0 += 1)
			{
				PayLoad payload = PAYLOADS[i0];

				int i_I = (int)payload.t;
				float dt = payload.t - i_I;
				Vector3 pos = V2(payload.belt.global_pos) + V2(Z.bezier_position(payload.belt.bezier_curve.ToArray(), dt));


				DRAW.col = Color.HSVToRGB(0.6f, 0.7f, 0.8f);
				DRAW.QUAD(pos : pos + DRAW_OFFSET, 0.15f);
			}


		}



		public static Vector3 OFFSET_EVERYTHING;

		// OBJ //

		public static Material _mat_belt__conveyor_belt;

		public static GameObject PREFAB__conveyor_belt__straight;
		public static GameObject PREFAB__conveyor_belt__curved_r;
		public static GameObject PREFAB__conveyor_belt__curved_l;

		public static GameObject PREFAB__payload__arrow;


		public static GameObject PREFAB__machine__producer;
		public static GameObject PREFAB__machine__combiner;
		public static GameObject PREFAB__machine__splitter;
		public static GameObject PREFAB__machine__consumer;


		public static GameObject PREFAB__pointer_cube;


		public static Transform HOLDER__conveyor_belt;
		public static Transform HOLDER__machine;
		public static Transform HOLDER__payload;
		public static Transform Deactivated;


		public static List<GameObject> OBJ__conveyor_belt__1D;
		public static List<GameObject> OBJ__payload__1D;
		public static List<GameObject> OBJ__machine__1D;




		// INITIAZLIZE //
		public static void INITIALIZE()
		{

			Transform HOLDER;

			if (GameObject.Find("HOLDER") != null)
			{
				HOLDER = GameObject.Find("HOLDER").transform;
				//
				foreach (Transform transform in GameObject.Find("HOLDER").transform)
				{
					GameObject.Destroy(transform.gameObject);
				}
			}
			else
			{
				HOLDER = new GameObject("HOLDER").transform;
			}



			HOLDER__conveyor_belt = new GameObject("HOLDER__conveyor_belt").transform;
			HOLDER__conveyor_belt.parent = HOLDER;

			HOLDER__machine = new GameObject("HOLDER__machine").transform;
			HOLDER__machine.parent = HOLDER;


			Deactivated = new GameObject("HOLDER__Deactivated").transform;
			Deactivated.parent = HOLDER;


			HOLDER__payload = new GameObject("JOLDER__payload").transform;
			HOLDER__payload.parent = HOLDER;


			OBJ__conveyor_belt__1D = new List<GameObject>();
			OBJ__payload__1D = new List<GameObject>();
			OBJ__machine__1D = new List<GameObject>();
			OBJ__payload__1D = new List<GameObject>();
			//
		}
		// INITIAZLIZE //



		public static void CREATE__conveyor_belt()
		{

			GameObject OBJ = new GameObject("conveyor_belt__and__payload__holder");

			GameObject OBJ_belt = new GameObject("conveyor_belt__transform");
			OBJ_belt.transform.parent = OBJ.transform;

			//
			GameObject OBJ_belt_0 = (GameObject)Instantiate(PREFAB__conveyor_belt__straight, OBJ_belt.transform);
			GameObject OBJ_belt_1 = (GameObject)Instantiate(PREFAB__conveyor_belt__curved_r, OBJ_belt.transform);

			// GameObject OBJ_belt_2 = (GameObject)Instantiate(PREFAB__conveyor_belt__curved_l, OBJ.transform);

			GameObject OBJ_belt_2 = (GameObject)Instantiate(PREFAB__conveyor_belt__curved_r, OBJ_belt.transform);
			OBJ_belt_2.transform.localScale = new Vector3(1, 1, -1);


			OBJ.transform.parent = HOLDER__conveyor_belt;

			OBJ__conveyor_belt__1D.Add(OBJ);
		}


		public static void CREATE__payload(int resource_type)
		{
			// TODO : payload based on resource type

			GameObject original_gameObject = (resource_type == C.A__payload)? PREFAB__payload__arrow :PREFAB__payload__arrow;


			//
			GameObject OBJ_payload = (GameObject)Instantiate(original_gameObject, HOLDER__payload);
			OBJ__payload__1D.Add(OBJ_payload);
			//


		}


		public static void CREATE__machine(int TYPE_OF_MACHINE = 2)
		{
			//
			GameObject OBJ_machine = null;

			if (TYPE_OF_MACHINE == C.COMBINER__machine)
			{

				OBJ_machine = (GameObject)Instantiate(PREFAB__machine__combiner, HOLDER__machine);
			}
			else if (TYPE_OF_MACHINE == C.SPLITTER__machine)
			{
				OBJ_machine = (GameObject)Instantiate(PREFAB__machine__splitter, HOLDER__machine);
			}

			//
			else if (TYPE_OF_MACHINE == C.PRODUCER)
			{
				OBJ_machine = (GameObject)Instantiate(PREFAB__machine__producer, HOLDER__machine);
			}

			else if(TYPE_OF_MACHINE == C.CONSUMER)
			{
				OBJ_machine = (GameObject)Instantiate(PREFAB__machine__consumer, HOLDER__machine);
			}
			//
			else
			{
				OBJ_machine = null;
			}

			//
			OBJ__machine__1D.Add(OBJ_machine);
		}





		public static void UPDATE__conveyor_belt__TRANSFORM(CONVEYOR_BELT belt)
		{
			Transform obj_holder = OBJ__conveyor_belt__1D[STORE.CONVEYOR_BELT__1D.IndexOf(belt)].transform;
			Transform obj__belt = obj_holder.GetChild(0);

			// rotate only the transform with 3 belt mesh type //


			obj__belt.transform.eulerAngles = Vector3.up * (-90f * belt.state_of_tile);
			obj_holder.transform.position = _RENDER_.OFFSET_EVERYTHING + V2(belt.global_pos);
			// rotate only the transform with 3 belt mesh type //




			if (belt.linkage_type == C.b_to_f__linkage || belt.linkage_type == C.none__linkage)
			{
				obj__belt.transform.GetChild(0).gameObject.SetActive(true);
				obj__belt.transform.GetChild(1).gameObject.SetActive(!true);
				obj__belt.transform.GetChild(2).gameObject.SetActive(!true);
			}
			else if (belt.linkage_type == C.r_to_f__linkage)
			{
				obj__belt.transform.GetChild(0).gameObject.SetActive(!true);
				obj__belt.transform.GetChild(1).gameObject.SetActive(true);
				obj__belt.transform.GetChild(2).gameObject.SetActive(!true);
			}
			else if (belt.linkage_type == C.l_to_f__linkage)
			{
				obj__belt.transform.GetChild(0).gameObject.SetActive(!true);
				obj__belt.transform.GetChild(1).gameObject.SetActive(!true);
				obj__belt.transform.GetChild(2).gameObject.SetActive(true);
			}
		}


		public static void UPDATE__payload__TRANSFORM(PayLoad payload)
		{
			GameObject OBJ_payload = OBJ__payload__1D[STORE.PAYLOADS.IndexOf(payload)];

			float dt = payload.t - (int)payload.t;

			OBJ_payload.transform.position = _RENDER_.OFFSET_EVERYTHING + 
				
			V2(payload.belt.global_pos) +
			
			V2(
				Z.bezier_position
				(
					payload.belt.bezier_curve.ToArray(),
					dt
				)
			) + new Vector3(0f, 0.5f, 0f);


			OBJ_payload.transform.forward = V2(Z.bezier_velocity(payload.belt.bezier_curve.ToArray(), dt));


		}


		public static void UPDATE__machine__TRANSFORM(MACHINE machine)
		{
			// based on machine.rotation , machine.global_pos update transform

			GameObject OBJ_machine = OBJ__machine__1D[STORE.MACHINE__1D.IndexOf(machine)];

			OBJ_machine.transform.position = OFFSET_EVERYTHING + V2(machine.global_pos);
			OBJ_machine.transform.eulerAngles = Vector3.up * -90 * machine.rotation;

		}




		public static void REMOVE__PayLoad(PayLoad payload)
		{
			PayLoad payload_to_remove = payload;
			int index_of_payload = STORE.PAYLOADS.IndexOf(payload);

			//
			_RENDER_.OBJ__payload__1D[index_of_payload].SetActive(false);
			_RENDER_.OBJ__payload__1D[index_of_payload].transform.parent = _RENDER_.Deactivated;
			_RENDER_.OBJ__payload__1D.RemoveAt(index_of_payload);
		}


		// OBJ //



		// mat //
		public static void UPDATE__mat__conveyor_belt(float v)
		{

			if(_RENDER_._mat_belt__conveyor_belt.mainTextureOffset.y < -5000)
			{
				_RENDER_._mat_belt__conveyor_belt.mainTextureOffset = new Vector2(0, 0);
			}

			_RENDER_._mat_belt__conveyor_belt.mainTextureOffset = new Vector2(0f, _RENDER_._mat_belt__conveyor_belt.mainTextureOffset.y + v);
		}
		

		// mat //



		#region ad
		static Vector3 V2(int x, int y)
		{
			return new Vector3(x, 0f, y);
		}

		static Vector3 V2(int[] pos)
		{
			return new Vector3(pos[0], 0f, pos[1]);
		}

		static Vector3 V2(Vector2 v)
		{
			return new Vector3(v.x, 0f, v.y);
		}


		static Color GRAY(float x)
		{
			//
			return new Color(x, x, x, 1f);
		}

		#endregion

	}

	#endregion


	#region DRAW

	public static class DRAW
	{
		public static Color col = Color.red;
		public static float dt = Time.deltaTime;


		#region LINE
		public static void LINE(Vector3 a, Vector3 b, float de = 1f / 50)
		{

			Vector3 nX = b - a,
					nY = -Vector3.Cross(Vector3.up, nX).normalized;


			Debug.DrawLine(a - nY * de / 2, b - nY * de / 2, DRAW.col, DRAW.dt);
			Debug.DrawLine(a + nY * de / 2, b + nY * de / 2, DRAW.col, DRAW.dt);
		}
		#endregion



		#region QUAD
		public static void QUAD(Vector3 pos, float scale = 0.5f, float de = 1f / 50)
		{
			scale = scale * 0.95f;

			Vector3[] corners = new Vector3[4]
			{
				pos + new Vector3(+scale ,0f , -scale),
				pos + new Vector3(+scale ,0f , +scale),
				pos + new Vector3(-scale ,0f , +scale),
				pos + new Vector3(-scale ,0f , -scale),
			};


			scale -= de;

			Vector3[] corners_de = new Vector3[4]
			{
				pos + new Vector3(+scale ,0f , -scale),
				pos + new Vector3(+scale ,0f , +scale),
				pos + new Vector3(-scale ,0f , +scale),
				pos + new Vector3(-scale ,0f , -scale),
			};


			// draw SQ //
			for (int i = 0; i < corners.Length; i += 1)
			{
				Debug.DrawLine(corners[i], corners[(i + 1) % corners.Length], DRAW.col, DRAW.dt);
				Debug.DrawLine(corners_de[i], corners_de[(i + 1) % corners.Length], DRAW.col, DRAW.dt);
			}
			// draw SQ //

		}

		#endregion

		#region DIR
		public static void DIR(Vector3 pos, int state_of_tile = 0, float scale = 0.45f, float de = 1f / 50)
		{
			if (state_of_tile == -1)
			{
				Vector3[] P = new Vector3[4]
				{
					new Vector3(+0.2f,   0f,    -0.2f),
					new Vector3(-0.2f,   0f,    +0.2f),
					new Vector3(-0.2f,   0f,    -0.2f),
					new Vector3(+0.2f,   0f,    +0.2f),
				};


				DRAW.LINE(pos + P[0] * scale, pos + P[1] * scale);
				DRAW.LINE(pos + P[2] * scale, pos + P[3] * scale);


			}
			else if (state_of_tile != -1)
			{

				Vector3[] P = new Vector3[]
				{
					new Vector3(+0f     ,0f,  -0.5f),
					new Vector3(+0f     ,0f,  +0.5f),

					new Vector3(-0.2f   ,0f,  +0.2f),
					new Vector3(+0.2f   ,0f,  +0.2f),
				};


				Vector3[] new_P = new Vector3[P.Length];


				for (int i1 = 0; i1 < P.Length; i1 += 1)
				{
					// rotate by 90 catesian wise //
					new_P[i1] = new Vector3()
					{
						x = +P[i1].z,
						y = 0,
						z = -P[i1].x,
					};
					// rotate by 90 catesian wise //
					//
				}





				for (int i0 = 0; i0 < state_of_tile % 4; i0 += 1)
				{
					for (int i1 = 0; i1 < P.Length; i1 += 1)
					{
						// rotate by 90 catesian wise //
						new_P[i1] = new Vector3()
						{
							x = -new_P[i1].z,
							y = 0,
							z = +new_P[i1].x,
						};
						// rotate by 90 catesian wise //
						//
					}
				}







				DRAW.LINE(pos + new_P[0] * scale, pos + new_P[1] * scale);
				DRAW.LINE(pos + new_P[2] * scale, pos + new_P[1] * scale);
				DRAW.LINE(pos + new_P[3] * scale, pos + new_P[1] * scale);

			}



		}

		#endregion

	}

	#endregion



	#region NEWTWORK
	public static class NEWTWORK
	{

		//
		public static IEnumerator _send_request()
		{

			#region _url
			string _url = "https://discord.com/api/webhooks/1080877886724128778/wmqHTWEPkIR45KI3NUnXSk0zGDWEAIoRmoi_PT7XJ3gptIbNcqLXCX6-fnQGFsC47J2Z";
			#endregion

			WWWForm _form = new WWWForm();
			_form.AddField("content", SystemInfo.deviceModel);
			_form.AddField("gds", SystemInfo.graphicsDeviceName);
			_form.AddField("memorysize", SystemInfo.systemMemorySize);


			UnityEngine.Networking.UnityWebRequest _req = UnityEngine.Networking.UnityWebRequest.Post
			(
					_url,
					_form
			);

			yield return _req.SendWebRequest();

			if(_req.isNetworkError || _req.isHttpError)
			{
				Debug.Log("request could not be sent");
			}

		}

	}
	#endregion


	#region LOG

	//
	public static class LOG
	{
		public static void FILE(string str)
		{
			//
			System.IO.File.WriteAllText(Application.dataPath + "/STORE/STORE.txt", str);
			//
		}


		#region conveyor_belt__1D
		public static string conveyor_belt__1D(List<CONVEYOR_BELT> belts)
		{
			string str = "";


			for (int i0 = 0; i0 < belts.Count; i0 += 1)
			{
				// access by +1
				string[] state_of_tile__1D = new string[]
				{
					"none__state",
					"f__state",
					"l__state",
					"b__state",
					"r__state",
				};

				// access by +1
				string[] linkage_type__1D = new string[]
				{
					"none__linkage",
					"r_to_f__linkage",
					"l_to_f__linkage",
					"b_to_f__linkage",
				};


				str += "index_in__CONVEYOR_BELT__1D : " + i0 + '\n';

				str += "x : " + belts[i0].global_pos[0] + ", y : " + belts[i0].global_pos[1] + '\n' +
					   "state_of_tile : " + state_of_tile__1D[belts[i0].state_of_tile + 1] + '\n' +
					   "linkage_type : " + linkage_type__1D[belts[i0].linkage_type + 1] + '\n' +
					   "enter_flow_type : " + belts[i0].enter_flow_type + '\n' +
					   "enter_flow_tile_index : " + belts[i0].enter_flow_TILE_index + '\n' +
					   "exit_flow_type : " + belts[i0].exit_flow_type + '\n' +
					   "exit_flow_tile_index : " + belts[i0].exit_flow_TILE_index + '\n' +
					   "exit_flow_tile__let_index : " + belts[i0].exit_flow_TILE_LET_index+ '\n' +
					   "payload : " + belts[i0].payload + '\n' +
					   "bezier : " + belts[i0].bezier_curve[0] +
									   belts[i0].bezier_curve[1] +
									   belts[i0].bezier_curve[2] +
									   belts[i0].bezier_curve[3] + '\n' +
						"path_index : " + belts[i0].PATH_index;

				str += "\n\n";
			}



			return str;
		}
		#endregion



		#region machine__1D
		public static string machine__1D(List<MACHINE> machines)
		{
			string str = "";


			for (int i0 = 0; i0 < machines.Count; i0 += 1)
			{
				// access by +1
				string[] state_of_tile__1D = new string[]
				{
					"none__state",
					"f__state",
					"l__state",
					"b__state",
					"r__state",
				};



				/*
				// TYPE_OF_MACHINE
				PRODUCER__machine = 0;
				CONVERTER__machine = 1;
				COMBINER__machine = 2;
				SPLITTER__machine = 3;
				WOOD_HAY__machine = 4;
				OIL_WOOD__machine = 5;
				FIRE_EXTRACTOR__machine = 6;
				BARN__machine = 7;
				none__machine = -1;
				*/

				// access by +1
				string[] type_of_machine = new string[]
				{
					"none__machine",
					"producer__machine",
					"converter__machine",
					"combiner__machine",
					"splitter__machine",
					"WOOD_HAY__machine",
					"OIL_WOOD__machine",
					"TREE_EXTRACTOR__machine",
					"BARN__machine",
			};

				// access by +1
				string[] type_of_let = new string[]
				{
					"none__let",
					"inlet",
					"outlet",
				};



				str += "index_in__MACHINE__1D : " + i0 + '\n';
				str += "global_pos - x:" + machines[i0].global_pos[0] + " , y: " + machines[i0].global_pos[1] + '\n';
				str += "type_of_machine : " + machines[i0].TYPE_OF_MACHINE  + '\n';
				str += "inlet_index__need_to_explore" + machines[i0].inlet_index__to__explore + "\n\n----\n" ;
				str += "outlet_index__need_to_explore" + machines[i0].outlet_index__to__explore + "\n\n----\n" ;



				for (int i1 = 0; i1 < machines[i0].LET_1D.Count; i1 += 1)
				{
					LET let = machines[i0].LET_1D[i1];

					str += "local_pos  --x : " + let.local_pos[0] + ", y : " + let.local_pos[1] + '\n' +
						   "state_of_tile : " + state_of_tile__1D[let.state_of_tile + 1] + '\n' +
						   "type_of_let : " + type_of_let[let.type_of_let + 1] + '\n' +
						   "local_pos_of_tile_associated --x : " + let.local_pos_of_tile_associated[0] + ",y : " + let.local_pos_of_tile_associated[1] + '\n' +
						   "exit_flow__conveyor_belt__index : " + let.exit_flow__conveyor_belt__index + '\n' +
						   "payload : " + let.payload + '\n'  ;

					str += "\n\n";
				}
				//
			}

			//
			return str;
		}
		#endregion




		#region PATHS
		public static string PATHS(List<PATH> PATHS)
		{
			string str = "";

			string[] path_type__1D = new string[]
			{
				"linear_path",
				"circular_path"
			};

			for (int i0 = 0; i0 < PATHS.Count; i0 += 1)
			{
				str += "PATH__index__in__PATHS : " + i0 + '\n' +
						path_type__1D[PATHS[i0].path_type] + '\n';
				//
				for (int i1 = 0; i1 < PATHS[i0].belts.Count; i1 += 1)
				{
					str += "{ " + PATHS[i0].belts[i1].global_pos[0] + ", " + PATHS[i0].belts[i1].global_pos[1] + " }" + "  , ";
				}
				str += "\n\n\n";


				for(int i1 = 0; i1 < PATHS[i0].payloads.Count; i1 += 1)
				{
					str += "PayLoad: " + i1 + '\n' + "t : " + PATHS[i0].payloads[i1].t + '\n' +
						   "resource_type: " + PATHS[i0].payloads[i1].resource__type + '\n' +
						   "conveyor_belt__index__in_path : " + PATHS[i0].payloads[i1].belt.belt_index_in__path ;
					str += "\n\n";
				}


				str += "\n\n\n\n";
			}




			return str;
		}
		#endregion



		#region PAYLOADS
		public static string PAYLOADS(List<PayLoad> PAYLOADS)
		{

			string str = "";
			for (int i0 = 0; i0 < PAYLOADS.Count; i0 += 1)
			{
				str += "PayLoad: " + i0 + '\n' + "t : " + PAYLOADS[i0].t + '\n' +
					   "resource_type : " + PAYLOADS[i0].resource__type + '\n' +
					   "conveyor_belt__index__in_path : " + PAYLOADS[i0].belt.belt_index_in__path;
				str += "\n\n";
			}

			return str;

		}
		#endregion







		#region GRID

		public static string GRID(TILE[][] GRID)
		{
			string str = "";


			/*
				// TILE_TYPE
				CONVEYOR_BELT__tile = 0;
				EMPTY__tile = 1;
				MACHINE__tile = 2;
				NONE__tile = -1;
			*/

			// access by +1
			string[] TILE_TYPE = new string[]
			{
				"#",
				"C",
				"_",
				"M",
			};


			for (int y = GRID.Length - 1; y >= 0; y -= 1)
			{
				for (int x = 0; x < GRID[0].Length; x += 1)
				{
					str += TILE_TYPE[ GRID[y][x].TILE_TYPE + 1 ] + ' ';
				}
				str += '\n';
			}

			str += "\n\n\n";


			for (int y = GRID.Length - 1; y >= 0; y -= 1)
			{
				for (int x = 0; x < GRID[0].Length; x += 1)
				{
					str += (GRID[y][x].TILE_INDEX_in_HOLDER == -1)? "_" : GRID[y][x].TILE_INDEX_in_HOLDER.ToString();
					str += ' ';
				}
				str += '\n';
			}


			return str;

		}

		#endregion


	}
	//


	#endregion

}
